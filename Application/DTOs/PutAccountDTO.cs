namespace BankAPI.DTOs;

public class PutAccountDTO
{
    public int Id { get; set; }
    public string AccountName { get; set; }
    public float Amount { get; set; }
    public int CustomerId { get; set; }
}