namespace Invest.CrossCutting.Auth.ViewModels
{
    public class ContextUserViewModel
    {
        public string Id { get; set; }

        public string Document { get; set; }

        public bool IsAuthenticated { get; set; }

        public string Name { get; set; }
    }
}