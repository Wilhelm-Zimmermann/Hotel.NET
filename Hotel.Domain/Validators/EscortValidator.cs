
using Hotel.Domain.Entities;

namespace Hotel.Domain.Validators
{
    public class EscortValidator
    {
        public Escort EscortItem { get; private set; }
        public bool IsValid { get; private set; }

        public EscortValidator(Escort escortItem)
        {
            EscortItem = escortItem;
            IsValid = true;
        }

        public void Validate()
        {
            if (EscortItem.Name.Length <= 0)
                IsValid = false;

            if(EscortItem.BirthDate > DateTime.UtcNow)
                IsValid = false;

            if (EscortItem.Relationship.Length <= 0)
                IsValid = false;
        }
    }
}
