/*******************************************************************************
 *  Copyright 2012-2019 Amazon.com, Inc. or its affiliates. All Rights Reserved.
 *  Licensed under the Apache License, Version 2.0 (the "License"). You may not use
 *  this file except in compliance with the License. A copy of the License is located at
 *
 *  http://aws.amazon.com/apache2.0
 *
 *  or in the "license" file accompanying this file.
 *  This file is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR
 *  CONDITIONS OF ANY KIND, either express or implied. See the License for the
 *  specific language governing permissions and limitations under the License.
 * *****************************************************************************
 *
 *  AWS Tools for Windows (TM) PowerShell (TM)
 *
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using Amazon.PowerShell.Common;
using Amazon.Runtime;
using Amazon.ServerMigrationService;
using Amazon.ServerMigrationService.Model;

namespace Amazon.PowerShell.Cmdlets.SMS
{
    /// <summary>
    /// Creates or updates a validation configuration for the specified application.
    /// </summary>
    [Cmdlet("Write", "SMSAppValidationConfiguration", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the AWS Server Migration Service PutAppValidationConfiguration API operation.", Operation = new[] {"PutAppValidationConfiguration"}, SelectReturnType = typeof(Amazon.ServerMigrationService.Model.PutAppValidationConfigurationResponse))]
    [AWSCmdletOutput("None or Amazon.ServerMigrationService.Model.PutAppValidationConfigurationResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.ServerMigrationService.Model.PutAppValidationConfigurationResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class WriteSMSAppValidationConfigurationCmdlet : AmazonServerMigrationServiceClientCmdlet, IExecutor
    {
        
        #region Parameter AppId
        /// <summary>
        /// <para>
        /// <para>The ID of the application.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String AppId { get; set; }
        #endregion
        
        #region Parameter AppValidationConfiguration
        /// <summary>
        /// <para>
        /// <para>The configuration for application validation.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AppValidationConfigurations")]
        public Amazon.ServerMigrationService.Model.AppValidationConfiguration[] AppValidationConfiguration { get; set; }
        #endregion
        
        #region Parameter ServerGroupValidationConfiguration
        /// <summary>
        /// <para>
        /// <para>The configuration for instance validation.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ServerGroupValidationConfigurations")]
        public Amazon.ServerMigrationService.Model.ServerGroupValidationConfiguration[] ServerGroupValidationConfiguration { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ServerMigrationService.Model.PutAppValidationConfigurationResponse).
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the AppId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^AppId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^AppId' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.AppId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-SMSAppValidationConfiguration (PutAppValidationConfiguration)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ServerMigrationService.Model.PutAppValidationConfigurationResponse, WriteSMSAppValidationConfigurationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.AppId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.AppId = this.AppId;
            #if MODULAR
            if (this.AppId == null && ParameterWasBound(nameof(this.AppId)))
            {
                WriteWarning("You are passing $null as a value for parameter AppId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.AppValidationConfiguration != null)
            {
                context.AppValidationConfiguration = new List<Amazon.ServerMigrationService.Model.AppValidationConfiguration>(this.AppValidationConfiguration);
            }
            if (this.ServerGroupValidationConfiguration != null)
            {
                context.ServerGroupValidationConfiguration = new List<Amazon.ServerMigrationService.Model.ServerGroupValidationConfiguration>(this.ServerGroupValidationConfiguration);
            }
            
            // allow further manipulation of loaded context prior to processing
            PostExecutionContextLoad(context);
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.ServerMigrationService.Model.PutAppValidationConfigurationRequest();
            
            if (cmdletContext.AppId != null)
            {
                request.AppId = cmdletContext.AppId;
            }
            if (cmdletContext.AppValidationConfiguration != null)
            {
                request.AppValidationConfigurations = cmdletContext.AppValidationConfiguration;
            }
            if (cmdletContext.ServerGroupValidationConfiguration != null)
            {
                request.ServerGroupValidationConfigurations = cmdletContext.ServerGroupValidationConfiguration;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                object pipelineOutput = null;
                pipelineOutput = cmdletContext.Select(response, this);
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response
                };
            }
            catch (Exception e)
            {
                output = new CmdletOutput { ErrorResponse = e };
            }
            
            return output;
        }
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.ServerMigrationService.Model.PutAppValidationConfigurationResponse CallAWSServiceOperation(IAmazonServerMigrationService client, Amazon.ServerMigrationService.Model.PutAppValidationConfigurationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Server Migration Service", "PutAppValidationConfiguration");
            try
            {
                #if DESKTOP
                return client.PutAppValidationConfiguration(request);
                #elif CORECLR
                return client.PutAppValidationConfigurationAsync(request).GetAwaiter().GetResult();
                #else
                        #error "Unknown build edition"
                #endif
            }
            catch (AmazonServiceException exc)
            {
                var webException = exc.InnerException as System.Net.WebException;
                if (webException != null)
                {
                    throw new Exception(Utils.Common.FormatNameResolutionFailureMessage(client.Config, webException.Message), webException);
                }
                throw;
            }
        }
        
        #endregion
        
        internal partial class CmdletContext : ExecutorContext
        {
            public System.String AppId { get; set; }
            public List<Amazon.ServerMigrationService.Model.AppValidationConfiguration> AppValidationConfiguration { get; set; }
            public List<Amazon.ServerMigrationService.Model.ServerGroupValidationConfiguration> ServerGroupValidationConfiguration { get; set; }
            public System.Func<Amazon.ServerMigrationService.Model.PutAppValidationConfigurationResponse, WriteSMSAppValidationConfigurationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}