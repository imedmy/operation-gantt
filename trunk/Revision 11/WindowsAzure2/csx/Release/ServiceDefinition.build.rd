<?xml version="1.0" encoding="utf-8"?>
<serviceModel xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" name="WindowsAzure2" generation="1" functional="0" release="0" Id="4a0e94c9-dd7a-407d-803a-ff33c7a487c2" dslVersion="1.2.0.0" xmlns="http://schemas.microsoft.com/dsltools/RDSM">
  <groups>
    <group name="WindowsAzure2Group" generation="1" functional="0" release="0">
      <componentports>
        <inPort name="ProjectRevision5:Endpoint1" protocol="http">
          <inToChannel>
            <lBChannelMoniker name="/WindowsAzure2/WindowsAzure2Group/LB:ProjectRevision5:Endpoint1" />
          </inToChannel>
        </inPort>
      </componentports>
      <settings>
        <aCS name="ProjectRevision5:Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" defaultValue="">
          <maps>
            <mapMoniker name="/WindowsAzure2/WindowsAzure2Group/MapProjectRevision5:Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" />
          </maps>
        </aCS>
        <aCS name="ProjectRevision5Instances" defaultValue="[1,1,1]">
          <maps>
            <mapMoniker name="/WindowsAzure2/WindowsAzure2Group/MapProjectRevision5Instances" />
          </maps>
        </aCS>
      </settings>
      <channels>
        <lBChannel name="LB:ProjectRevision5:Endpoint1">
          <toPorts>
            <inPortMoniker name="/WindowsAzure2/WindowsAzure2Group/ProjectRevision5/Endpoint1" />
          </toPorts>
        </lBChannel>
      </channels>
      <maps>
        <map name="MapProjectRevision5:Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" kind="Identity">
          <setting>
            <aCSMoniker name="/WindowsAzure2/WindowsAzure2Group/ProjectRevision5/Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" />
          </setting>
        </map>
        <map name="MapProjectRevision5Instances" kind="Identity">
          <setting>
            <sCSPolicyIDMoniker name="/WindowsAzure2/WindowsAzure2Group/ProjectRevision5Instances" />
          </setting>
        </map>
      </maps>
      <components>
        <groupHascomponents>
          <role name="ProjectRevision5" generation="1" functional="0" release="0" software="C:\Users\GARY\Desktop\Semester2\4. Project\GoogleCodeDownloads\ProjectRevision 11R\WindowsAzure2\csx\Release\roles\ProjectRevision5" entryPoint="base\x86\WaHostBootstrapper.exe" parameters="base\x86\WaIISHost.exe " memIndex="1792" hostingEnvironment="frontendadmin" hostingEnvironmentVersion="2">
            <componentports>
              <inPort name="Endpoint1" protocol="http" portRanges="80" />
            </componentports>
            <settings>
              <aCS name="Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" defaultValue="" />
              <aCS name="__ModelData" defaultValue="&lt;m role=&quot;ProjectRevision5&quot; xmlns=&quot;urn:azure:m:v1&quot;&gt;&lt;r name=&quot;ProjectRevision5&quot;&gt;&lt;e name=&quot;Endpoint1&quot; /&gt;&lt;/r&gt;&lt;/m&gt;" />
            </settings>
            <resourcereferences>
              <resourceReference name="DiagnosticStore" defaultAmount="[4096,4096,4096]" defaultSticky="true" kind="Directory" />
              <resourceReference name="EventStore" defaultAmount="[1000,1000,1000]" defaultSticky="false" kind="LogStore" />
            </resourcereferences>
          </role>
          <sCSPolicy>
            <sCSPolicyIDMoniker name="/WindowsAzure2/WindowsAzure2Group/ProjectRevision5Instances" />
            <sCSPolicyFaultDomainMoniker name="/WindowsAzure2/WindowsAzure2Group/ProjectRevision5FaultDomains" />
          </sCSPolicy>
        </groupHascomponents>
      </components>
      <sCSPolicy>
        <sCSPolicyFaultDomain name="ProjectRevision5FaultDomains" defaultPolicy="[2,2,2]" />
        <sCSPolicyID name="ProjectRevision5Instances" defaultPolicy="[1,1,1]" />
      </sCSPolicy>
    </group>
  </groups>
  <implements>
    <implementation Id="53486bd0-d4ef-4e67-b31d-262b47fc4273" ref="Microsoft.RedDog.Contract\ServiceContract\WindowsAzure2Contract@ServiceDefinition.build">
      <interfacereferences>
        <interfaceReference Id="79bae634-a157-49ba-8f0b-5b09271f2d2a" ref="Microsoft.RedDog.Contract\Interface\ProjectRevision5:Endpoint1@ServiceDefinition.build">
          <inPort>
            <inPortMoniker name="/WindowsAzure2/WindowsAzure2Group/ProjectRevision5:Endpoint1" />
          </inPort>
        </interfaceReference>
      </interfacereferences>
    </implementation>
  </implements>
</serviceModel>