using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoProgramacion5.APIConnection
{

    public class APIModel
    {
        #region 
        private string _MYURL;
        private string _Method;
        private string _AuthorizationType;
        private string _ContentType;
        private string _ContentLength;
        private string _Accept;
        private string _ProxyUser;
        private string _ProxyPassword;
        private string _ProxyURL;
        private List<APIParameters> _ParameterArray = new List<APIParameters>();
        private List<APIHeaders> _HeaderArray = new List<APIHeaders>();
        private string _Body;
        private string _Key;
        private string _Value;
        private string _Token;
        private string _APIID;
        private string _APIPassword;
        private string _FileName;
        private string _Host;
        private string _UserAgent;

        private CookieCollection _cookieCollection;

        private ModelExceptions _exceptions;
        #endregion



        #region 
        public APIModel()
        {
            _MYURL = "";
            _Method = "";
            _AuthorizationType = "";
            _ContentType = "";
            _ContentLength = "";
            _Accept = "";
            _ProxyUser = "";
            _ProxyPassword = "";
            _ProxyURL = "";
            _Body = "";
            _Key = "";
            _Value = "";
            _Token = "";
            _APIID = "";
            _APIPassword = "";
            _FileName = "";
            _Host = "";
            _UserAgent = "";
            Header.Key = "";
            Header.Value = "";
            Parameter.Key = "";
            Parameter.Value = "";

            _cookieCollection = null;
        }
        #endregion

        #region 

        public string MYURL
        {
            get
            {
                return _MYURL;
            }
            set
            {
                _MYURL = value;
            }
        }
        public string Method
        {
            get
            {
                return _Method;
            }
            set
            {
                _Method = value;
            }
        }
        public string AuthorizationType
        {
            get
            {
                return _AuthorizationType;
            }
            set
            {
                _AuthorizationType = value;
            }
        }
        public string ContentType
        {
            get
            {
                return _ContentType;
            }
            set
            {
                _ContentType = value;
            }
        }
        public string ContentLength
        {
            get
            {
                return _ContentLength;
            }
            set
            {
                _ContentLength = value;
            }
        }
        public string Accept
        {
            get
            {
                return _Accept;
            }
            set
            {
                _Accept = value;
            }
        }
        public string ProxyUser
        {
            get
            {
                return _ProxyUser;
            }
            set
            {
                _ProxyUser = value;
            }
        }
        public string ProxyPassword
        {
            get
            {
                return _ProxyPassword;
            }
            set
            {
                _ProxyPassword = value;
            }
        }
        public APIParameters Parameter { get; set; } = new APIParameters();

        public APIHeaders Header { get; set; } = new APIHeaders();
        public string Body
        {
            get
            {
                return _Body;
            }
            set
            {
                _Body = value;
            }
        }
        public string Key
        {
            get
            {
                return _Key;
            }
            set
            {
                _Key = value;
            }
        }
        public string Value
        {
            get
            {
                return _Value;
            }
            set
            {
                _Value = value;
            }
        }
        public string Token
        {
            get
            {
                return _Token;
            }
            set
            {
                _Token = value;
            }
        }
        public string APIID
        {
            get
            {
                return _APIID;
            }
            set
            {
                _APIID = value;
            }
        }
        public string APIPassword
        {
            get
            {
                return _APIPassword;
            }
            set
            {
                _APIPassword = value;
            }
        }
        public string FileName
        {
            get
            {
                return _FileName;
            }
            set
            {
                _FileName = value;
            }
        }
        public string ProxyURL
        {
            get
            {
                return _ProxyURL;
            }
            set
            {
                _ProxyURL = value;
            }
        }
        public List<APIParameters> ParameterArray
        {
            get
            {
                return _ParameterArray;
            }
            set
            {
                _ParameterArray = value;
            }
        }
        public List<APIHeaders> HeaderArray
        {
            get
            {
                return _HeaderArray;
            }
            set
            {
                _HeaderArray = value;
            }
        }
        public ModelExceptions Exceptions
        {
            get
            {
                return _exceptions;
            }
            set
            {
                _exceptions = value;
            }
        }
        public string Host
        {
            get
            {
                return _Host;
            }
            set
            {
                _Host = value;
            }
        }
        public string UserAgent
        {
            get
            {
                return _UserAgent;
            }
            set
            {
                _UserAgent = value;
            }
        }
        public CookieCollection CookieCollection
        {
            get
            {
                return _cookieCollection;
            }
            set
            {
                _cookieCollection = value;
            }
        }
        #endregion



        public void AddHeader(ref APIModel API)
        {
            APIHeaders header = new APIHeaders();
            header.Key = API.Key;
            header.Value = API.Value;
            API.HeaderArray.Add(header);

        }

        public void AddParameter(APIModel API)
        {
            APIParameters parameter = new APIParameters();
            parameter.Key = API.Key;
            parameter.Value = API.Value;
            API.ParameterArray.Add(parameter);

        }
        public void APICall(ref APIModel API)
        {
            HttpWebRequest request;
            HttpWebResponse response;
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            try
            {
                API.MYURL = API.MYURL;
                if (API.ParameterArray.Count > 0)
                {
                    int counter = 1;
                    foreach (var Param in API.ParameterArray)
                    {
                        if (counter == 1)
                            API.MYURL = API.MYURL + "?" + Param.Key + "=" + Param.Value;
                        else
                            API.MYURL = API.MYURL + "&" + Param.Key + "=" + Param.Value;
                        counter++;
                    }
                }
                request = (HttpWebRequest)WebRequest.Create(API.MYURL);
                if (API.ProxyUser != "" & API.ProxyPassword != "")
                {
                    var proxyObject = new WebProxy(API.ProxyURL);
                    NetworkCredential nCredential = new NetworkCredential()
                    {
                        UserName = API.ProxyUser,
                        Password = API.ProxyPassword
                    };
                    proxyObject.Credentials = nCredential;
                    WebRequest.DefaultWebProxy = proxyObject;
                    request.Proxy = proxyObject;
                }
                if (API.Method != "")
                    request.Method = API.Method;
                if (API.ContentType != "")
                    request.ContentType = API.ContentType;
                if (API.Accept != "")
                    request.Accept = API.Accept;
                if (API.Host != "")
                    request.Host = API.Host;
                if (API.ContentLength != "")
                    request.ContentLength = long.Parse(API.ContentLength);

                if (API.HeaderArray.Count > 0)
                {
                    foreach (var Head in API.HeaderArray)
                        request.Headers.Add(Head.Key, Head.Value);
                }

                request.CookieContainer = new CookieContainer();
                if (CookieCollection != null)
                    request.CookieContainer.Add(CookieCollection);

                if (API.Body != "")
                {
                    Stream bodyStream;
                    var bodyByte = Encoding.UTF8.GetBytes(API.Body);
                    bodyStream = request.GetRequestStream();
                    bodyStream.Write(bodyByte, 0, bodyByte.Length);
                    bodyStream.Close();
                }
                response = (HttpWebResponse)request.GetResponse();
                var responseData = response.GetResponseStream();
                StreamReader streamReader = new StreamReader(responseData);
                string ResponseText = streamReader.ReadToEnd();
                API.Exceptions = AssignAPIValues(response.CharacterSet, response.ContentEncoding, response.ContentLength.ToString(), response.ContentType, response.Cookies, response.Headers, response.IsFromCache, response.IsMutuallyAuthenticated, response.LastModified, response.Method, response.ProtocolVersion, response.ResponseUri.ToString(), response.Server, response.StatusCode, response.StatusDescription, response.SupportsHeaders, ResponseText);
            }
            catch (Exception ex)
            {
                API.Exceptions = AssignAPIValues(null, null, null, null, null, null, default, default, default, null, null, null, null, default, null, default, null, ex.Message, ex.Source, true);
            }
        }

        private ModelExceptions AssignAPIValues(string CharacterSet = "", string ContentEncoding = "", string ContentLength = "", string ContentType = "", CookieCollection Cookies = null, WebHeaderCollection Headers = null, bool IsFromCache = false, bool IsMutuallyAuthenticated = false, DateTime LastModified = default, string Method = "", Version ProtocolVersion = null, string ResponseUri = null, string Server = "", HttpStatusCode StatusCode = default, string StatusDescription = "", bool SupportsHeaders = false, string ResponseText = "", string ExceptionMessage = "", string ExceptionSource = "", bool IsError = false)
        {
            ModelExceptions myObject = new ModelExceptions();
            myObject.CharacterSet = CharacterSet;
            myObject.ContentEncoding = ContentEncoding;
            myObject.ContentLength = ContentLength;
            myObject.ContentType = ContentType;
            myObject.Cookies = Cookies;
            myObject.Headers = Headers;
            myObject.IsFromCache = IsFromCache;
            myObject.IsMutuallyAuthenticated = IsMutuallyAuthenticated;
            myObject.LastModified = LastModified;
            myObject.Method = Method;
            myObject.ProtocolVersion = ProtocolVersion;
            myObject.ResponseUri = ResponseUri;
            myObject.Server = Server;
            myObject.StatusCode = StatusCode;
            myObject.StatusDescription = StatusDescription;
            myObject.SupportsHeaders = SupportsHeaders;
            myObject.ResponseText = ResponseText;
            myObject.ExceptionMessage = ExceptionMessage;
            myObject.ExceptionSource = ExceptionSource;
            myObject.IsError = IsError;

            return myObject;
        }

    }

    public class APIHeaders
    {
        private string _Key;
        private string _Value;
        public APIHeaders()
        {
            _Key = "";
            _Value = "";
        }
        public string Key
        {
            get
            {
                return _Key;
            }
            set
            {
                _Key = value;
            }
        }
        public string Value
        {
            get
            {
                return _Value;
            }
            set
            {
                _Value = value;
            }
        }
    }

    public class APIParameters
    {
        private string _Key;
        private string _Value;

        public APIParameters()
        {
            _Key = "";
            _Value = "";
        }

        public string Key
        {
            get
            {
                return _Key;
            }
            set
            {
                _Key = value;
            }
        }

        public string Value
        {
            get
            {
                return _Value;
            }
            set
            {
                _Value = value;
            }
        }
    }
}
