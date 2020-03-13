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
using Amazon.GameLift;
using Amazon.GameLift.Model;

namespace Amazon.PowerShell.Cmdlets.GML
{
    /// <summary>
    /// <b>This action is part of Amazon GameLift FleetIQ with game server groups, which
    /// is in preview release and is subject to change.</b><para>
    /// Terminates a game server group and permanently deletes the game server group record.
    /// You have several options for how these resources are impacted when deleting the game
    /// server group. Depending on the type of delete action selected, this action may affect
    /// three types of resources: the game server group, the corresponding Auto Scaling group,
    /// and all game servers currently running in the group. 
    /// </para><para>
    /// To delete a game server group, identify the game server group to delete and specify
    /// the type of delete action to initiate. Game server groups can only be deleted if they
    /// are in ACTIVE or ERROR status.
    /// </para><para>
    /// If the delete request is successful, a series of actions are kicked off. The game
    /// server group status is changed to DELETE_SCHEDULED, which prevents new game servers
    /// from being registered and stops autoscaling activity. Once all game servers in the
    /// game server group are de-registered, GameLift FleetIQ can begin deleting resources.
    /// If any of the delete actions fail, the game server group is placed in ERROR status.
    /// </para><para>
    /// GameLift FleetIQ emits delete events to Amazon CloudWatch.
    /// </para><para><b>Learn more</b></para><para><a href="https://docs.aws.amazon.com/gamelift/latest/developerguide/gsg-intro.html">GameLift
    /// FleetIQ Guide</a></para><para><b>Related operations</b></para><ul><li><para><a>CreateGameServerGroup</a></para></li><li><para><a>ListGameServerGroups</a></para></li><li><para><a>DescribeGameServerGroup</a></para></li><li><para><a>UpdateGameServerGroup</a></para></li><li><para><a>DeleteGameServerGroup</a></para></li><li><para><a>ResumeGameServerGroup</a></para></li><li><para><a>SuspendGameServerGroup</a></para></li></ul>
    /// </summary>
    [Cmdlet("Remove", "GMLGameServerGroup", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.High)]
    [OutputType("Amazon.GameLift.Model.GameServerGroup")]
    [AWSCmdlet("Calls the Amazon GameLift Service DeleteGameServerGroup API operation.", Operation = new[] {"DeleteGameServerGroup"}, SelectReturnType = typeof(Amazon.GameLift.Model.DeleteGameServerGroupResponse))]
    [AWSCmdletOutput("Amazon.GameLift.Model.GameServerGroup or Amazon.GameLift.Model.DeleteGameServerGroupResponse",
        "This cmdlet returns an Amazon.GameLift.Model.GameServerGroup object.",
        "The service call response (type Amazon.GameLift.Model.DeleteGameServerGroupResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class RemoveGMLGameServerGroupCmdlet : AmazonGameLiftClientCmdlet, IExecutor
    {
        
        #region Parameter DeleteOption
        /// <summary>
        /// <para>
        /// <para>The type of delete to perform. Options include:</para><ul><li><para>SAFE_DELETE – Terminates the game server group and EC2 Auto Scaling group only when
        /// it has no game servers that are in IN_USE status.</para></li><li><para>FORCE_DELETE – Terminates the game server group, including all active game servers
        /// regardless of their utilization status, and the EC2 Auto Scaling group. </para></li><li><para>RETAIN – Does a safe delete of the game server group but retains the EC2 Auto Scaling
        /// group as is.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.GameLift.GameServerGroupDeleteOption")]
        public Amazon.GameLift.GameServerGroupDeleteOption DeleteOption { get; set; }
        #endregion
        
        #region Parameter GameServerGroupName
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the game server group to delete. Use either the <a>GameServerGroup</a>
        /// name or ARN value.</para>
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
        public System.String GameServerGroupName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'GameServerGroup'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.GameLift.Model.DeleteGameServerGroupResponse).
        /// Specifying the name of a property of type Amazon.GameLift.Model.DeleteGameServerGroupResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "GameServerGroup";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the GameServerGroupName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^GameServerGroupName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^GameServerGroupName' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.GameServerGroupName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Remove-GMLGameServerGroup (DeleteGameServerGroup)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.GameLift.Model.DeleteGameServerGroupResponse, RemoveGMLGameServerGroupCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.GameServerGroupName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.DeleteOption = this.DeleteOption;
            context.GameServerGroupName = this.GameServerGroupName;
            #if MODULAR
            if (this.GameServerGroupName == null && ParameterWasBound(nameof(this.GameServerGroupName)))
            {
                WriteWarning("You are passing $null as a value for parameter GameServerGroupName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            
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
            var request = new Amazon.GameLift.Model.DeleteGameServerGroupRequest();
            
            if (cmdletContext.DeleteOption != null)
            {
                request.DeleteOption = cmdletContext.DeleteOption;
            }
            if (cmdletContext.GameServerGroupName != null)
            {
                request.GameServerGroupName = cmdletContext.GameServerGroupName;
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
        
        private Amazon.GameLift.Model.DeleteGameServerGroupResponse CallAWSServiceOperation(IAmazonGameLift client, Amazon.GameLift.Model.DeleteGameServerGroupRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon GameLift Service", "DeleteGameServerGroup");
            try
            {
                #if DESKTOP
                return client.DeleteGameServerGroup(request);
                #elif CORECLR
                return client.DeleteGameServerGroupAsync(request).GetAwaiter().GetResult();
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
            public Amazon.GameLift.GameServerGroupDeleteOption DeleteOption { get; set; }
            public System.String GameServerGroupName { get; set; }
            public System.Func<Amazon.GameLift.Model.DeleteGameServerGroupResponse, RemoveGMLGameServerGroupCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.GameServerGroup;
        }
        
    }
}