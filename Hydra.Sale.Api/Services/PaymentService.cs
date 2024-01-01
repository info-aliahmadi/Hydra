using Hydra.Infrastructure.Data.Extension;
using Hydra.Kernel.Extensions;
using Hydra.Kernel.Interfaces.Data;
using Hydra.Kernel.Models;
using Hydra.Sale.Core.Domain;
using Hydra.Sale.Core.Interfaces;
using Hydra.Sale.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Hydra.Sale.Api.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IQueryRepository _queryRepository;
        private readonly ICommandRepository _commandRepository;
        public PaymentService(IQueryRepository queryRepository, ICommandRepository commandRepository)
        {
            _queryRepository = queryRepository;
            _commandRepository = commandRepository;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="dataGrid"></param>
        /// <returns></returns>
        public async Task<Result<PaginatedList<PaymentModel>>> GetList(GridDataBound dataGrid)
        {
            var result = new Result<PaginatedList<PaymentModel>>();

            var list = await (from payment in _queryRepository.Table<Payment>()
                              select new PaymentModel()
                              {
                                  Id = payment.Id,
                                  OrderId = payment.OrderId,
                                  TransactionTrackingCode = payment.TransactionTrackingCode,
                                  PaymentTrackingCode = payment.PaymentTrackingCode,
                                  PaymentDateUtc = payment.PaymentDateUtc,
                                  PaymentTypeId = payment.PaymentTypeId,
                                  Status = payment.Status,
                                  Deleted = payment.Deleted,
                                  CreatedOnUtc = payment.CreatedOnUtc,
                                  CardType = payment.CardType,
                                  CardName = payment.CardName,
                                  CardNumber = payment.CardNumber,
                                  MaskedCreditCardNumber = payment.MaskedCreditCardNumber,
                                  CardCvv2 = payment.CardCvv2,
                                  CardExpirationMonth = payment.CardExpirationMonth,
                                  CardExpirationYear = payment.CardExpirationYear,

                              }).OrderByDescending(x => x.Id).ToPaginatedListAsync(dataGrid);

            result.Data = list;

            return result;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Result<PaymentModel>> GetById(int id)
        {
            var result = new Result<PaymentModel>();
            var payment = await _queryRepository.Table<Payment>().FirstOrDefaultAsync(x => x.Id == id);

            var paymentModel = new PaymentModel()
            {
                Id = payment.Id,
                OrderId = payment.OrderId,
                TransactionTrackingCode = payment.TransactionTrackingCode,
                PaymentTrackingCode = payment.PaymentTrackingCode,
                PaymentDateUtc = payment.PaymentDateUtc,
                PaymentTypeId = payment.PaymentTypeId,
                Status = payment.Status,
                Deleted = payment.Deleted,
                CreatedOnUtc = payment.CreatedOnUtc,
                CardType = payment.CardType,
                CardName = payment.CardName,
                CardNumber = payment.CardNumber,
                MaskedCreditCardNumber = payment.MaskedCreditCardNumber,
                CardCvv2 = payment.CardCvv2,
                CardExpirationMonth = payment.CardExpirationMonth,
                CardExpirationYear = payment.CardExpirationYear,

            };
            result.Data = paymentModel;

            return result;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="paymentModel"></param>
        /// <returns></returns>
        public async Task<Result<PaymentModel>> Add(PaymentModel paymentModel)
        {
            var result = new Result<PaymentModel>();
            try
            {
                bool isExist = await _queryRepository.Table<Payment>().AnyAsync(x => x.Id == paymentModel.Id);
                if (isExist)
                {
                    result.Status = ResultStatusEnum.ItsDuplicate;
                    result.Message = "The Id already exist";
                    result.Errors.Add(new Error(nameof(paymentModel.Id), "The Id already exist"));
                    return result;
                }
                var payment = new Payment()
                {
                    OrderId = paymentModel.OrderId,
                    TransactionTrackingCode = paymentModel.TransactionTrackingCode,
                    PaymentTrackingCode = paymentModel.PaymentTrackingCode,
                    PaymentDateUtc = paymentModel.PaymentDateUtc,
                    PaymentTypeId = paymentModel.PaymentTypeId,
                    Status = paymentModel.Status,
                    Deleted = paymentModel.Deleted,
                    CreatedOnUtc = paymentModel.CreatedOnUtc,
                    CardType = paymentModel.CardType,
                    CardName = paymentModel.CardName,
                    CardNumber = paymentModel.CardNumber,
                    MaskedCreditCardNumber = paymentModel.MaskedCreditCardNumber,
                    CardCvv2 = paymentModel.CardCvv2,
                    CardExpirationMonth = paymentModel.CardExpirationMonth,
                    CardExpirationYear = paymentModel.CardExpirationYear,

                };

                await _commandRepository.InsertAsync(payment);
                await _commandRepository.SaveChangesAsync();

                paymentModel.Id = payment.Id;

                result.Data = paymentModel;

                return result;
            }
            catch (Exception e)
            {
                result.Message = e.Message;
                result.Status = ResultStatusEnum.ExceptionThrowed;
                return result;
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="paymentModel"></param>
        /// <returns></returns>
        public async Task<Result<PaymentModel>> Update(PaymentModel paymentModel)
        {
            var result = new Result<PaymentModel>();
            try
            {
                var payment = await _queryRepository.Table<Payment>().FirstAsync(x => x.Id == paymentModel.Id);
                if (payment is null)
                {
                    result.Status = ResultStatusEnum.NotFound;
                    result.Message = "The Payment not found";
                    return result;
                }
                bool isExist = await _queryRepository.Table<Payment>().AnyAsync(x => x.Id != paymentModel.Id);
                if (isExist)
                {
                    result.Status = ResultStatusEnum.ItsDuplicate;
                    result.Message = "The Id already exist";
                    result.Errors.Add(new Error(nameof(paymentModel.Id), "The Id already exist"));
                    return result;
                }
                payment.OrderId = paymentModel.OrderId;
                payment.TransactionTrackingCode = paymentModel.TransactionTrackingCode;
                payment.PaymentTrackingCode = paymentModel.PaymentTrackingCode;
                payment.PaymentDateUtc = paymentModel.PaymentDateUtc;
                payment.PaymentTypeId = paymentModel.PaymentTypeId;
                payment.Status = paymentModel.Status;
                payment.Deleted = paymentModel.Deleted;
                payment.CreatedOnUtc = paymentModel.CreatedOnUtc;
                payment.CardType = paymentModel.CardType;
                payment.CardName = paymentModel.CardName;
                payment.CardNumber = paymentModel.CardNumber;
                payment.MaskedCreditCardNumber = paymentModel.MaskedCreditCardNumber;
                payment.CardCvv2 = paymentModel.CardCvv2;
                payment.CardExpirationMonth = paymentModel.CardExpirationMonth;
                payment.CardExpirationYear = paymentModel.CardExpirationYear;

                _commandRepository.UpdateAsync(payment);
                await _commandRepository.SaveChangesAsync();

                result.Data = paymentModel;

                return result;
            }
            catch (Exception e)
            {
                result.Message = e.Message;
                result.Status = ResultStatusEnum.ExceptionThrowed;
                return result;
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Result> Delete(int id)
        {
            var result = new Result();
            var payment = await _queryRepository.Table<Payment>().FirstOrDefaultAsync(x => x.Id == id);
            if (payment is null)
            {
                result.Status = ResultStatusEnum.NotFound;
                result.Message = "The Payment not found";
                return result;
            }

            _commandRepository.DeleteAsync(payment);
            await _commandRepository.SaveChangesAsync();

            return result;
        }

    }
}