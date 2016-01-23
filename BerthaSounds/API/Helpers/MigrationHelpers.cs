using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace API.Helpers
{
    public class MigrationHelpers
    {
        /// <summary>
        /// Runs an INSERT command against a specified table and column.
        /// </summary>
        /// <param name="table">Table to run the command against (without dbo.).</param>
        /// <param name="columns">The columns to insert the data into.</param>
        /// <param name="data">The data you wish to insert.</param>
        /// <returns></returns>
        public static string InsertInto(string table, string[] columns, string data)
        {
            return string.Format(@"INSERT INTO dbo.[{0}]({1})
                        VALUES('{2}')", table, columns, data);
        }

		/// <summary>
		/// Sets Identity_Insert On / Off on a specified table. Caution: Remember to turn it off at the end of the migration.
		/// </summary>
		/// <param name="table">The table you wish to modify.</param>
		/// <param name="identityInsert">Whether you want to toggle Identity_Insert On or Off.</param>
		/// <returns></returns>
	    public static string SetIdentityInsert(string table, bool identityInsert)
	    {
		    return string.Format(@"SET IDENTITY_INSERT dbo.[{0}] {1}", table, identityInsert ? "ON" : "OFF");
	    }

        /// <summary>
        /// Adds a new role to the database.
        /// </summary>
        /// <param name="roleName">The name of the role you wish to add.</param>
        /// <returns></returns>
        public static string AddNewRole(string roleName)
        {
            return string.Format(@"INSERT INTO dbo.AspNetRoles(Id, Name) VALUES ('{0}', '{1}')", Guid.NewGuid(), roleName);
        }

        /// <summary>
        /// Add a user to the designated role.
        /// </summary>
        /// <param name="userName">The UserName of the user you wish to add to the role.</param>
        /// <param name="roleName">The role to add the user to.</param>
        /// <returns></returns>
        public static string AddUserToRole(string userName, string roleName)
        {
            return string.Format(@"INSERT INTO dbo.AspNetUserRoles(
                                    UserId,
                                    RoleId)
                                   VALUES(
                                    (SELECT Id FROM dbo.AspNetUsers WHERE UserName = '{0}'),
                                    (SELECT Id FROM dbo.AspNetRoles WHERE Name = '{1}'))",
                                                                                         userName,
                                                                                         roleName);
        }
    }
}
