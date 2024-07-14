using BFI.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Data.SqlClient;
using System.Data;
using Dapper;
using System.Numerics;
using System.Reflection.Metadata;
using System;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;


namespace BFI.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly string _cs;
        private IConfiguration configuration;

        public HomeController(ILogger<HomeController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _cs = configuration.GetConnectionString("DbContext");
            this.configuration = configuration;

            VersionMapping();
        }


        public async Task<IActionResult> Index()
        {
            List<Brands> brands = configuration.GetSection("Brands").Get<List<Brands>>();
            var host = Request.Host.Value;
            string name = brands.FirstOrDefault(o => o.Url.Equals(host)).Name.ToString();
            string shortName = brands.FirstOrDefault(s => s.Url.Equals(host)).ShortName;

            return await GetDataView(name, shortName, false);

        }

        public async Task<IActionResult> GetDataView(string typeName, string shortName, bool lastVersion)
        {
            try
            {
                using var connection = new SqlConnection(_cs);

                var data = await connection.QueryAsync<VersionUpdate>("uspr_get_sw", new
                {
                    @st_brand = typeName,
                    @last_ver = lastVersion,
                    
                }, commandType: CommandType.StoredProcedure);

                return View("index", new VersionVM { Updates = data, Type = typeName, ShortName = shortName, });

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public void VersionMapping()
        {
            new List<Type> {
             typeof(VersionUpdate),
              typeof(VersionUpdateType)
                }
            .ForEach(t => SqlMapper.SetTypeMap(t, new CustomPropertyTypeMap(t, (type, columnName) => type.GetProperties().FirstOrDefault(prop => Mapper.GetDescriptionFromAttribute(prop) == columnName))));

            SqlMapper.AddTypeHandler(typeof(List<VersionUpdateChange>), new DapperJsonTypeHandler());
        }
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
