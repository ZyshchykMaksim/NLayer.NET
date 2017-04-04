using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace NLayer.NET.PL.API.Configurations
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class IdentityConfiguration : ConfigurationSection
    {
        /// <summary>
        /// 
        /// </summary>
        [ConfigurationProperty("UserValidator")]
        public UserValidatorElement UserValidator => ((UserValidatorElement)(base["UserValidator"]));

        /// <summary>
        /// 
        /// </summary>
        [ConfigurationProperty("PasswordValidator")]
        public PasswordValidatorElement PasswordValidator => ((PasswordValidatorElement)(base["PasswordValidator"]));
    }

    /// <summary>
    /// 
    /// </summary>
    public sealed class UserValidatorElement : ConfigurationElement
    {
        public const bool AllowOnlyAlphanumericUserNamesDefault = false;
        public const bool RequireUniqueEmailDefault = true;

        /// <summary>
        /// Only allow [A-Za-z0-9@_] in UserNames
        /// </summary>
        [ConfigurationProperty("AllowOnlyAlphanumericUserNames", DefaultValue = AllowOnlyAlphanumericUserNamesDefault, IsRequired = true)]
        public bool AllowOnlyAlphanumericUserNames
        {
            get { return ((bool)(base["AllowOnlyAlphanumericUserNames"])); }
            set { base["AllowOnlyAlphanumericUserNames"] = value; }
        }

        /// <summary>
        ///  If set, enforces that emails are non empty, valid, and unique
        /// </summary>
        [ConfigurationProperty("RequireUniqueEmail", DefaultValue = RequireUniqueEmailDefault, IsRequired = true)]
        public bool RequireUniqueEmail
        {
            get { return ((bool)(base["RequireUniqueEmail"])); }
            set { base["RequireUniqueEmail"] = value; }
        }
    }


    /// <summary>
    /// 
    /// </summary>
    public sealed class PasswordValidatorElement : ConfigurationElement
    {
        public const bool RequireDigitDefault = false;
        public const int RequiredLengthDefault = 6;
        public const bool RequireLowercaseDefault = false;
        public const bool RequireNonLetterOrDigitDefault = false;
        public const bool RequireUppercaseDefault = false;

        /// <summary>
        ///  Require a digit ('0' - '9')
        /// </summary>
        [ConfigurationProperty("RequireDigit", DefaultValue = RequireDigitDefault, IsRequired = true)]
        public bool RequireDigit
        {
            get { return ((bool)(base["RequireDigit"])); }
            set { base["RequireDigit"] = value; }
        }

        /// <summary>
        ///  Minimum required length
        /// </summary>
        [ConfigurationProperty("RequiredLength", DefaultValue = RequiredLengthDefault, IsRequired = true)]
        public int RequiredLength
        {
            get { return ((int)(base["RequiredLength"])); }
            set { base["RequiredLength"] = value; }
        }

        /// <summary>
        /// Require a lower case letter ('a' - 'z')
        /// </summary>
        [ConfigurationProperty("RequireLowercase", DefaultValue = RequireLowercaseDefault, IsRequired = true)]
        public bool RequireLowercase
        {
            get { return ((bool)(base["RequireLowercase"])); }
            set { base["RequireLowercase"] = value; }
        }


        /// <summary>
        /// Require a non letter or digit character
        /// </summary>
        [ConfigurationProperty("RequireNonLetterOrDigit", DefaultValue = RequireNonLetterOrDigitDefault, IsRequired = true)]
        public bool RequireNonLetterOrDigit
        {
            get { return ((bool)(base["RequireNonLetterOrDigit"])); }
            set { base["RequireNonLetterOrDigit"] = value; }
        }


        /// <summary>
        /// Require an upper case letter ('A' - 'Z')
        /// </summary>
        [ConfigurationProperty("RequireUppercase", DefaultValue = RequireUppercaseDefault, IsRequired = true)]
        public bool RequireUppercase
        {
            get { return ((bool)(base["RequireUppercase"])); }
            set { base["RequireUppercase"] = value; }
        }
    }
}