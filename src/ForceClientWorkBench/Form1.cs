using System;
using System.Configuration;
using System.Dynamic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Salesforce.Common;
using Salesforce.Common.Models.Json;
using Salesforce.Force.FunctionalTests.Models;
using Salesforce.Common.Models;
using Salesforce.Force;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ForceClientWorkBench
{
    public partial class Form1 : Form
    {
        private static string _consumerKey = ConfigurationManager.AppSettings["ConsumerKey"];
        private static string _consumerSecret = ConfigurationManager.AppSettings["ConsumerSecret"];
        private static string _username = ConfigurationManager.AppSettings["Username"];
        private static string _password = ConfigurationManager.AppSettings["Password"];
        private static string _organizationId = ConfigurationManager.AppSettings["OrganizationId"];
        private static string _token = ConfigurationManager.AppSettings["TokenRequestEndpointUrl"];

        private AuthenticationClient _auth;
        private ForceClient _client;


        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_consumerKey) && string.IsNullOrEmpty(_consumerSecret) && string.IsNullOrEmpty(_username) && string.IsNullOrEmpty(_password) && string.IsNullOrEmpty(_organizationId))
            {
                _consumerKey = Environment.GetEnvironmentVariable("ConsumerKey");
                _consumerSecret = Environment.GetEnvironmentVariable("ConsumerSecret");
                _username = Environment.GetEnvironmentVariable("Username");
                _password = Environment.GetEnvironmentVariable("Password");
                _organizationId = Environment.GetEnvironmentVariable("OrganizationId");
            }

            // Use TLS 1.2 (instead of defaulting to 1.0)
            const int SecurityProtocolTypeTls11 = 768;
            const int SecurityProtocolTypeTls12 = 3072;
            ServicePointManager.SecurityProtocol |= (SecurityProtocolType)(SecurityProtocolTypeTls12 | SecurityProtocolTypeTls11);

            _auth = new AuthenticationClient();
            _auth.UsernamePasswordAsync(_consumerKey, _consumerSecret, _username, _password, _token).Wait();

            _client = new ForceClient(_auth.InstanceUrl, _auth.AccessToken, _auth.ApiVersion);

            var lstAccounts = new List<IAttributedObject>();

            lstAccounts.Add(new AtrributedAccount
            {
                Name = "New Account 1",
                Description = "New Account Description",
                Attributes = new ObjectAttributes()
                {
                    Type = "Account",
                    ReferenceId = "ACC1",
                },
            });
            lstAccounts.Add(new AtrributedAccount
            {
                Name = "New Account 2",
                Description = "New Account Description",
                Attributes = new ObjectAttributes()
                {
                    Type = "Account",
                    ReferenceId = "ACC2",
                },
            });
            lstAccounts.Add(new AtrributedAccount
            {
                Name = "New Account 3",
                Description = "New Account Description",
                Attributes = new ObjectAttributes()
                {
                    Type = "Account",
                    ReferenceId = "ACC3",
                },
            });

            var theRequest = new CreateRequest()
            {
                Records = lstAccounts
            };

            var successResponse = _client.CreateCompositeTreeAsync("Account", theRequest);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_consumerKey) && string.IsNullOrEmpty(_consumerSecret) && string.IsNullOrEmpty(_username) && string.IsNullOrEmpty(_password) && string.IsNullOrEmpty(_organizationId))
            {
                _consumerKey = Environment.GetEnvironmentVariable("ConsumerKey");
                _consumerSecret = Environment.GetEnvironmentVariable("ConsumerSecret");
                _username = Environment.GetEnvironmentVariable("Username");
                _password = Environment.GetEnvironmentVariable("Password");
                _organizationId = Environment.GetEnvironmentVariable("OrganizationId");
            }

            // Use TLS 1.2 (instead of defaulting to 1.0)
            const int SecurityProtocolTypeTls11 = 768;
            const int SecurityProtocolTypeTls12 = 3072;
            ServicePointManager.SecurityProtocol |= (SecurityProtocolType)(SecurityProtocolTypeTls12 | SecurityProtocolTypeTls11);

            _auth = new AuthenticationClient();
            _auth.UsernamePasswordAsync(_consumerKey, _consumerSecret, _username, _password, _token).Wait();

            _client = new ForceClient(_auth.InstanceUrl, _auth.AccessToken, _auth.ApiVersion);

            CompositeRequestRoot _requestRoot = new CompositeRequestRoot();
            _requestRoot.allOrNone = true;
            Account _account1 = new Account();
            _account1.Name = "This for Composite 2 - Composite";
            CompositeRequest _request = new CompositeRequest();
            _request.body = _account1;
            _request.method = "PATCH";
            _request.referenceId = "UpdateAccountRef";
            _request.url = "/services/data/v37.0/sobjects/Account/0012C000008WyxNQAS";

            List<CompositeRequest> _requestList = new List<CompositeRequest>();
            _requestList.Add(_request);
            _requestRoot.compositeRequest = _requestList;

            var successResponse = _client.CreateCompositeAsync(_requestRoot);

        }
    }
}
