﻿using Microsoft.Extensions.Options;
using WebLibraryAPI.Models.Auth;

namespace WebLibraryAPI.OptionsSetup
{
    public class JwtOptionsSetup(IConfiguration configuration) : IConfigureOptions<JwtOptions>
    {
        private const string SectionName = "Jwt";
        private readonly IConfiguration _configuration = configuration;

        public void Configure(JwtOptions options)
        {
            _configuration.GetSection(SectionName).Bind(options);
        }
    }
}
