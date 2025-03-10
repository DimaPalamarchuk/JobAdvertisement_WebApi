using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Common.CrossCutting.Dtos;
using WebApi.Common.CrossCutting.Enums;


namespace WebApi.Common.CrossCutting.ValidationAttributes
{
    public class LocalizedStringRequiredAttribute : RequiredAttribute
    {
        private readonly string[] _uiSupportedLanguages = new string[] {"en", "pl"};

        private readonly LocalizedStringRequirementType _requirementType;

        public LocalizedStringRequiredAttribute(LocalizedStringRequirementType requirementType = LocalizedStringRequirementType.AtLeastOneLanguage)
        {
            _requirementType = requirementType;
        }

        public override bool IsValid(object? value)
        {
            LocalizedString localizedString = value as LocalizedString;
            if (localizedString != null)
            {
                if(_requirementType == LocalizedStringRequirementType.AtLeastOneLanguage)
                {
                    if(localizedString.Values.All(new Func<string, bool>(base.IsValid)))
                    {
                        return localizedString.Values.Count > 0;
                    }
                    return false;
                }

                if(localizedString.Values.All(new Func<string, bool>(base.IsValid)))
                {
                    return _uiSupportedLanguages.All(new Func<string, bool>(localizedString.ContainsKey));
                }
                return false;
            }
            return false;
        }
    }
}
