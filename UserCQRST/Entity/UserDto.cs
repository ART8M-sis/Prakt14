namespace UserCQRST.Data.Entities;
    public record UserDto(
        Guid Id,
        string FirstName,
        string Email,
        string Role,
        DateTime CreatedAt
    );