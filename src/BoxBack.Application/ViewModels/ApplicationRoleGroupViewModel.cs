namespace BoxBack.Application.ViewModels
{
    public class ApplicationRoleGroupViewModel
    {
        public string RoleId { get;set; }
        public string GroupId { get;set; }
        public string Name { get; set; }

        public ApplicationRoleViewModel ApplicationRole { get; set; }
        public ApplicationGroupViewModel ApplicationGroup { get; set; }
    }
}