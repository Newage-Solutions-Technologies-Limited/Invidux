using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Invidux_Data.Dtos.Response
{
    public class InvestmentTypeDto
    {
        public int Id { get; set; }
        public string Type { get; set; }
    }

    public class KycIdCardDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Expires { get; set; }
    }

    public class KycLevelDto
    {
        public int Id { get; set; }
        public string Status { get; set; }
    }

    public class KycStatusDto
    {
        public int Id { get; set; }
        public string Status { get; set; }
    }

    public class PaymentMethodDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class PropertyClassDto
    {
        public int Id { get; set; }
        public string Class { get; set; }
    }

    public class RoleDto
    {
        public string Id { get; set; }
        public string RoleName { get; set; }
    }

    public class SecurityTypeDto
    {
        public int Id { get; set; }
        public string Type { get; set; }
    }

    public class SubRoleDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string RoleId { get; set; }
        public string RoleName { get; set; }
    }

    public class TokenListingStatusDto
    {
        public int Id { get; set; }
        public string Status { get; set; }
    }
    public class TokenTransactionTypeDto
    {
        public int Id { get; set; }
        public string TransactionType { get; set; }
    }

    public class TransactionTypeDto
    {
        public int Id { get; set; }
        public string Type { get; set; }
    }
    public class TwoFactorCoverDto
    {
        public int Id { get; set; }
        public string Type { get; set; }
    }


    public class TwoFactorTypeDto
    {
        public int Id { get; set; }
        public string Type { get; set; }
    }
}
