using ClickHouse.Client.ADO;
using ClickHouse.Client.Utility;
using ClickHouse.EntityFrameworkCore.Extensions;
using gantt_practice_exercise_backend.Models;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace gantt_practice_exercise_backend.context
{
    public class ClickHouseContext : DbContext
    {
        private readonly string _connectionString;
        private readonly ILogger<ClickHouseContext> _logger;
        private readonly IConfiguration _configuration;

        public ClickHouseContext(IConfiguration configuration, ILogger<ClickHouseContext> logger)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("Clickhouse");
            _logger = logger;
        }


        //entities
        public DbSet<ProjectTask> ProjectTasks { get; set; }
        public DbSet<ProjectTaskLink> ProjectTaskLinks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseClickHouse(_connectionString);
        }




    }
}
