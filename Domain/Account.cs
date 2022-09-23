namespace Domain;

public class Account
{
    public int Id { get; set; }
    public string AccountName { get; set; }
    public float Amount { get; set; }
    public int CustomerId { get; set; }
    public virtual Customer? Customer { get; set; }
}