using DAL;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;


namespace WebApiDrive.Controllers
{
    [EnableCors(origins: "https://localhost:44365", headers: "*", methods: "*")]
    public class UserDataController : ApiController
    {
        [HttpGet]
        public Object GetToken(String login)
        {
            string key = "my_secret_key_12345";
            var issuer = "http://mysite.com";
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var permClaims = new List<Claim>();
            permClaims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
            //permClaims.Add(new Claim("login", login));

            var token = new JwtSecurityToken(issuer,
                              issuer,
                              permClaims,
                              expires: DateTime.Now.AddDays(1),
                              signingCredentials: credentials);
            var jwt_token = new JwtSecurityTokenHandler().WriteToken(token);
            return new { data = jwt_token };
        }


        [HttpPost]
        public Object Verify()
        {
            String login = HttpContext.Current.Request["login"];
            String password = HttpContext.Current.Request["password"];
            Object data = null;
            var exception = false;
            var url = "";
            var flag = false;
            Object tkn = null;
            int res = UserDAO.validateUser(login, password);
            if (res == 1)
            {
                tkn = GetToken(login);
                flag = true;
                url = "/User/Welcome";
            }
            if (res == -2)
            {
                exception = true;
            }
            data = new
            {
                user = login,
                token = tkn,
                exception1 = exception,
                valid = flag,
                urlToRedirect = url
            };
            return data;
        }
        [HttpPost]
        public Object InsertUser()
        {
            String login = HttpContext.Current.Request["login"];
            String uname = HttpContext.Current.Request["uname"];
            String password = HttpContext.Current.Request["password"];
            Object data = null;
            var url = "";
            var flag = false;
            var exception = false;
            var err = "";
            int res = UserDAO.insertUser(login, password, uname);
            if (res == 1)
            {
                flag = true;
                url = "/User/Welcome";
            }
            else if (res == -1)
            {
                flag = false;
                err = "Username already exists, try a different one";
            }
            else if (res == -2)
            {
                exception = true;
            }
            data = new
            {
                valid = flag,
                urlToRedirect = url,
                error = err,
                exception1 = exception
            };
            return data;
        }

        //[Authorize]
        [HttpPost]
        public List<FolderDTO> displayRoots()
        {
            int parent = Int32.Parse(HttpContext.Current.Request["parent"]);
            List<FolderDTO> data = UserDAO.getRoots(parent);
            return data;
        }

        //[Authorize]
        [HttpPost]
        public Object NewFolder()
        {
            String fname = HttpContext.Current.Request["fname"];
            int parent = Int32.Parse(HttpContext.Current.Request["parent"]);
            var exception = false;
            Object data = null;
            int id = UserDAO.makeNewFolder(fname, parent);
            if (id == -2)
            {
                exception = true;
            }
            data = new
            {
                exception1 = exception,
                fid = id
            };
            return data;
        }
    }
}