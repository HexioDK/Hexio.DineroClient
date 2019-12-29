namespace Hexio.DineroClient.Module
{
    public class SingleDineroAccountApiSettings : DineroApiSettings
    {
        public int OrganizationId { get; set; }
        public string ApiKey { get; set; }
    }
}