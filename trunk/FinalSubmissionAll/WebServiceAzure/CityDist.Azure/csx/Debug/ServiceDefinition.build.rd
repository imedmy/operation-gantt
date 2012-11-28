<?xml version="1.0" encoding="utf-8"?>
<serviceModel xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" name="CityDist.Azure" generation="1" functional="0" release="0" Id="84fb827b-a21f-4f7b-aede-dc56072c0f4d" dslVersion="1.2.0.0" xmlns="http://schemas.microsoft.com/dsltools/RDSM">
  <groups>
    <group name="CityDist.AzureGroup" generation="1" functional="0" release="0">
      <componentports>
        <inPort name="CityDist:Endpoint1" protocol="http">
          <inToChannel>
            <lBChannelMoniker name="/CityDist.Azure/CityDist.AzureGroup/LB:CityDist:Endpoint1" />
          </inToChannel>
        </inPort>
      </componentports>
      <settings>
        <aCS name="CityDist:Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" defaultValue="">
          <maps>
            <mapMoniker name="/CityDist.Azure/CityDist.AzureGroup/MapCityDist:Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" />
          </maps>
        </aCS>
        <aCS name="CityDistInstances" defaultValue="[1,1,1]">
          <maps>
            <mapMoniker name="/CityDist.Azure/CityDist.AzureGroup/MapCityDistInstances" />
          </maps>
        </aCS>
      </settings>
      <channels>
        <lBChannel name="LB:CityDist:Endpoint1">
          <toPorts>
            <inPortMoniker name="/CityDist.Azure/CityDist.AzureGroup/CityDist/Endpoint1" />
          </toPorts>
        </lBChannel>
      </channels>
      <maps>
        <map name="MapCityDist:Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" kind="Identity">
          <setting>
            <aCSMoniker name="/CityDist.Azure/CityDist.AzureGroup/CityDist/Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" />
          </setting>
        </map>
        <map name="MapCityDistInstances" kind="Identity">
          <setting>
            <sCSPolicyIDMoniker name="/CityDist.Azure/CityDist.AzureGroup/CityDistInstances" />
          </setting>
        </map>
      </maps>
      <components>
        <groupHascomponents>
          <role name="CityDist" generation="1" functional="0" release="0" software="G:\MiniProjectTuesday\WebServiceWEBRoles\CityDist\CityDist\CityDist.Azure\csx\Debug\roles\CityDist" entryPoint="base\x86\WaHostBootstrapper.exe" parameters="base\x86\WaIISHost.exe " memIndex="1792" hostingEnvironment="frontendadmin" hostingEnvironmentVersion="2">
            <componentports>
              <inPort name="Endpoint1" protocol="http" portRanges="80" />
            </componentports>
            <settings>
              <aCS name="Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" defaultValue="" />
              <aCS name="__ModelData" defaultValue="&lt;m role=&quot;CityDist&quot; xmlns=&quot;urn:azure:m:v1&quot;&gt;&lt;r name=&quot;CityDist&quot;&gt;&lt;e name=&quot;Endpoint1&quot; /&gt;&lt;/r&gt;&lt;/m&gt;" />
            </settings>
            <resourcereferences>
              <resourceReference name="DiagnosticStore" defaultAmount="[4096,4096,4096]" defaultSticky="true" kind="Directory" />
              <resourceReference name="EventStore" defaultAmount="[1000,1000,1000]" defaultSticky="false" kind="LogStore" />
            </resourcereferences>
          </role>
          <sCSPolicy>
            <sCSPolicyIDMoniker name="/CityDist.Azure/CityDist.AzureGroup/CityDistInstances" />
            <sCSPolicyFaultDomainMoniker name="/CityDist.Azure/CityDist.AzureGroup/CityDistFaultDomains" />
          </sCSPolicy>
        </groupHascomponents>
      </components>
      <sCSPolicy>
        <sCSPolicyFaultDomain name="CityDistFaultDomains" defaultPolicy="[2,2,2]" />
        <sCSPolicyID name="CityDistInstances" defaultPolicy="[1,1,1]" />
      </sCSPolicy>
    </group>
  </groups>
  <implements>
    <implementation Id="483103f1-ec59-40f1-9708-0b5cf19c4d1b" ref="Microsoft.RedDog.Contract\ServiceContract\CityDist.AzureContract@ServiceDefinition.build">
      <interfacereferences>
        <interfaceReference Id="aa527fab-b530-43e0-91f8-060dbf39fd5a" ref="Microsoft.RedDog.Contract\Interface\CityDist:Endpoint1@ServiceDefinition.build">
          <inPort>
            <inPortMoniker name="/CityDist.Azure/CityDist.AzureGroup/CityDist:Endpoint1" />
          </inPort>
        </interfaceReference>
      </interfacereferences>
    </implementation>
  </implements>
</serviceModel>