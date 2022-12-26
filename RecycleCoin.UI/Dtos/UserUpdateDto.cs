namespace RecycleCoin.UI.Dtos
{
    public class UserUpdateDto
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int CarbonAccount { get; set; } = 0;
        public int RecycleCoinAccount { get; set; } = 0;
    }
}