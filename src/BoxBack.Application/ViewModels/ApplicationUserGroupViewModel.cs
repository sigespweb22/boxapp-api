namespace BoxBack.Application.ViewModels
{
    public class ApplicationUserGroupViewModel
    {
        public string UserId { get;set; }
        public string GroupId { get;set; }
        public string Name { get; set; }

        public ApplicationGroupViewModel ApplicationGroup { get; set; }
    }
}