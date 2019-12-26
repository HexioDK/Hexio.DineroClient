namespace Hexio.DineroClient
{
    public static class QueryFilterCreator
    {
        public static readonly string Equals = "eq";

        public static string Execute(string paramName, string comparizonOperator, string value)
        {
            return $"queryFilter={paramName}+{comparizonOperator}+'{value}';";
        }
    }
}