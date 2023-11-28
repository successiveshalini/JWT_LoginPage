
using Microsoft.EntityFrameworkCore;
using JWTAuthentication.Model.APIDbCOntext;
namespace JWTAuthentication.Model.APIDbCOntext
{
    public class APIDbContext : DbContext
    {
        public APIDbContext(DbContextOptions<APIDbContext> options): base(options) { }
   
        public DbSet<JWTToken> JwtTokens { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    //Configure your database connection here
        //    optionsBuilder.UseSqlServer("JWTAuthentication");
        //    using (var context = new APIDbContext())
        //    {
        //        var jwtToken = new JWTToken { Token = "your_token_here" };
        //        context.JwtTokens.Add(jwtToken);
        //        context.SaveChanges();
        //    }


            // Configure your database connection here
           // optionsBuilder.UseSqlServer("your_connection_string");
        
    }
}
