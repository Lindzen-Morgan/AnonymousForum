using AnonymousForumz;
    
        public class User
        {
            public int Id { get; set; }
            public string Username { get; set; } = default!;
            public string Password { get; set; } = default!;
            public string Email { get; set; } = default!;
            public int CreatorId { get; set; } // Add this if missing

}



