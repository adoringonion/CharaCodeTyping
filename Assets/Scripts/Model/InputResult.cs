namespace Model
{
    public record InputResult;

    public sealed record Success(bool IsCompleted) : InputResult;

    public sealed record Fail : InputResult;
}