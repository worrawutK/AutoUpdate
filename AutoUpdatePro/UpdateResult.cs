namespace AutoUpdateProLibrary
{
    public class UpdateResult
    {
        public bool IsPass { get;internal set; }
        public string Cause { get;internal set; }

        public UpdateResult(bool isPass,string cause)
        {
            this.IsPass = isPass;
            this.Cause = cause;
        }

    }
}