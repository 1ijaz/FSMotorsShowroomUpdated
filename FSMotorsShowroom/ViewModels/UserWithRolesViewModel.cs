﻿namespace FSMotorsShowroom.ViewModels
{
    public class UserWithRolesViewModel
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public bool EmailConfirmed {  get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        
        public List<string> Roles { get; set; }
    }
}
