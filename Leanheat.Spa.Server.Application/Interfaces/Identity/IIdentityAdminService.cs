using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leanheat.Spa.Server.Application.Interfaces.Identity
{
    public interface IIdentityAdminService
    {
        // ===== Create Role || POST || ==================================================================
        public Task<IActionResult> CreateRole(string roleName);



        // ===== Get All Roles  || GET || ================================================================
        public Task<IActionResult> GetAllRoles();



        // ===== Edit Role - || Post || ==================================================================
        public Task<IActionResult> EditRole(string oldName, string newName);



        // ===== Remove Role - || Post || ================================================================
        public Task<IActionResult> RemoveRole(string roleName, string reAssignRole);



        // ===== Remove User from Role - || Post || ======================================================
        public Task<IActionResult> RemoveRoleFromUser(string email, string roleName);



        // ===== Add User To Role || Post || =============================================================
        public Task<IActionResult> EditUserInRole(string userEmail, string roleName);



        // ===== Get ALL Users - || GET || ===============================================================
        public Task<IActionResult> GetAllUsers();



        // ===== Get User - || GET || ====================================================================
        public Task<IActionResult> GetUser(string email);



        // ===== Get Users with Roles - || GET || ========================================================
        public Task<IActionResult> GetAllUsersWithRoles();



        // ===== Delete User - || Post || ================================================================
        public Task<IActionResult> DeleteUser(string email);


    }
}
