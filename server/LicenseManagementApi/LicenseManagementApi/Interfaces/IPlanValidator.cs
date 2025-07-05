namespace LicenseManagementApi.Interfaces
{
    public interface IPlanValidator
    {
        public void ValidatePlanBy(string name);

        public void ValidateOnLicenseAssign(int userId);

        public void ValidateOnLicenseUnassign(int userId);
    }
}
