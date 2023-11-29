using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Hydra.Infrastructure.Data;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Hydra.Infrastructure.Security.Domain;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;

namespace Hydra.Infrastructure.Security
{
    public static class DbContextStartup
    {
        public static void AddIdentityConfig(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("ReactOrigin",
                        builder =>
                        {
                            builder.WithOrigins("http://localhost:3000").AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
                        });
            });

            services.AddIdentityCore<User>(o => o.SignIn.RequireConfirmedAccount = false)
                 .AddRoles<Role>()
                 .AddEntityFrameworkStores<ApplicationDbContext>()
                 .AddDefaultTokenProviders();

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
                {
                    options.Configuration = new OpenIdConnectConfiguration();
                    options.SaveToken = true;
                    options.RequireHttpsMetadata = false;
                    options.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateIssuer = false, // on production make it true
                        ValidateAudience = false, // on production make it true
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidAudience = configuration["Authentication:Schemes:Bearer:ValidAudiences"],
                        ValidIssuer = configuration["Authentication:Schemes:Bearer:ValidIssuer"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Authentication:Schemes:Bearer:Secret"])),
                        ClockSkew = TimeSpan.Zero,

                    };
                    options.Events = new JwtBearerEvents
                    {
                        OnAuthenticationFailed = context =>
                        {
                            if (context.Exception.GetType() == typeof(SecurityTokenExpiredException))
                            {
                                context.Response.Headers.Add("IS-TOKEN-EXPIRED", "true");
                            }
                            return Task.CompletedTask;
                        }
                    };
                });
            //.AddCookie(options =>
            //{
            //    options.Cookie.Name = "HydraCookie";
            //    options.Cookie.HttpOnly = true;
            //    options.ExpireTimeSpan = TimeSpan.FromMinutes(60);
            //    options.LoginPath = new PathString("/Account/Login");
            //    options.AccessDeniedPath = new PathString("/Account/AccessDenied");
            //    options.LogoutPath = new PathString("/Account/Logout");
            //    // ReturnUrlParameter requires 
            //    //using Microsoft.AspNetCore.Authentication.Cookies;
            //    options.ReturnUrlParameter = CookieAuthenticationDefaults.ReturnUrlParameter;
            //    options.SlidingExpiration = true;
            //})


            services.AddAuthorization(options =>
            {
                // By default, all incoming requests will be authorized according to the default policy.
                //options.FallbackPolicy = options.DefaultPolicy;
            });
            //services.AddAuthorizationBuilder()
            //.AddPolicy("admin_greetings", policy =>
            //    policy
            //.RequireRole("admin")
            //.RequireScope("greetings_api"));


            services.Configure<IdentityOptions>(options =>
            {
                // Password settings.
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 5;
                options.Password.RequiredUniqueChars = 0;

                // Lockout settings.
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.AllowedForNewUsers = true;

                // User settings.
                options.User.AllowedUserNameCharacters =
                "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                options.User.RequireUniqueEmail = true;

                // Default SignIn settings.
                options.SignIn.RequireConfirmedEmail = false;
                options.SignIn.RequireConfirmedPhoneNumber = false;
            });

            // Hosting doesn't add IHttpContextAccessor by default
            services.AddHttpContextAccessor();
            // Identity services
            services.TryAddScoped<IUserValidator<User>, UserValidator<User>>();
            services.TryAddScoped<IPasswordValidator<User>, PasswordValidator<User>>();
            services.TryAddScoped<IPasswordHasher<User>, PasswordHasher<User>>();
            services.TryAddScoped<ILookupNormalizer, UpperInvariantLookupNormalizer>();
            services.TryAddScoped<IRoleValidator<Role>, RoleValidator<Role>>();
            // No interface for the error describer so we can add errors without rev'ing the interface
            services.TryAddScoped<IdentityErrorDescriber>();
            services.TryAddScoped<ISecurityStampValidator, SecurityStampValidator<User>>();
            services.TryAddScoped<ITwoFactorSecurityStampValidator, TwoFactorSecurityStampValidator<User>>();
            services.TryAddScoped<IUserClaimsPrincipalFactory<User>, UserClaimsPrincipalFactory<User, Role>>();
            services.TryAddScoped<UserManager<User>>();
            services.TryAddScoped<SignInManager<User>>();
            services.TryAddScoped<RoleManager<Role>>();

        }
    }
}
