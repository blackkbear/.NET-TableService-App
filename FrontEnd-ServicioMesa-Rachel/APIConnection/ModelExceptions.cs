using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoProgramacion5.APIConnection
{
    public class ModelExceptions
    {
        public string charSet;
        public string ContEncoding;
        public string ContLength;
        public string ContType;
        public System.Net.CookieCollection Cook;
        public System.Net.WebHeaderCollection Header;
        public bool IsCache;
        public bool IsMutuallyAuth;
        public DateTime Modified;
        public string Mthd;
        public Version ProtlVersion;
        public string RespUri;
        public string Ser;
        public System.Net.HttpStatusCode StatCode;
        public string StatDescription;
        public bool SupHeaders;
        public string ResponseTxt;
        public string ExMessage;
        public string ExSource;
        public bool IsErr;
        public object RetValue;

        public string CharacterSet
        {
            get
            {
                return charSet;
            }
            set
            {
                charSet = value;
            }
        }
        public string ContentEncoding
        {
            get
            {
                return ContEncoding;
            }
            set
            {
                ContEncoding = value;
            }
        }
        public string ContentLength
        {
            get
            {
                return ContLength;
            }
            set
            {
                ContLength = value;
            }
        }
        public string ContentType
        {
            get
            {
                return ContType;
            }
            set
            {
                ContType = value;
            }
        }
        public System.Net.CookieCollection Cookies
        {
            get
            {
                return Cook;
            }
            set
            {
                Cook = value;
            }
        }
        public System.Net.WebHeaderCollection Headers
        {
            get
            {
                return Header;
            }
            set
            {
                Header = value;
            }
        }
        public bool IsFromCache
        {
            get
            {
                return IsCache;
            }
            set
            {
                IsCache = value;
            }
        }
        public bool IsMutuallyAuthenticated
        {
            get
            {
                return IsMutuallyAuth;
            }
            set
            {
                IsMutuallyAuth = value;
            }
        }
        public DateTime LastModified
        {
            get
            {
                return Modified;
            }
            set
            {
                Modified = value;
            }
        }
        public string Method
        {
            get
            {
                return Mthd;
            }
            set
            {
                Mthd = value;
            }
        }
        public Version ProtocolVersion
        {
            get
            {
                return ProtlVersion;
            }
            set
            {
                ProtlVersion = value;
            }
        }
        public string ResponseUri
        {
            get
            {
                return RespUri;
            }
            set
            {
                RespUri = value;
            }
        }
        public string Server
        {
            get
            {
                return Ser;
            }
            set
            {
                Ser = value;
            }
        }
        public string StatusDescription
        {
            get
            {
                return StatDescription;
            }
            set
            {
                StatDescription = value;
            }
        }
        public System.Net.HttpStatusCode StatusCode
        {
            get
            {
                return StatCode;
            }
            set
            {
                StatCode = value;
            }
        }
        public bool SupportsHeaders
        {
            get
            {
                return SupHeaders;
            }
            set
            {
                SupHeaders = value;
            }
        }
        public string ResponseText
        {
            get
            {
                return ResponseTxt;
            }
            set
            {
                ResponseTxt = value;
            }
        }
        public string ExceptionMessage
        {
            get
            {
                return ExMessage;
            }
            set
            {
                ExMessage = value;
            }
        }
        public string ExceptionSource
        {
            get
            {
                return ExSource;
            }
            set
            {
                ExSource = value;
            }
        }
        public bool IsError
        {
            get
            {
                return IsErr;
            }
            set
            {
                IsErr = value;
            }
        }
        public object ReturnValue
        {
            get
            {
                return RetValue;
            }
            set
            {
                RetValue = value;
            }
        }
    }
}
