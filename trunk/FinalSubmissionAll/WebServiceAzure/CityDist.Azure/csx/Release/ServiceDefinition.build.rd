<?xml version="1.0" encoding="utf-8"?>
<serviceModel xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" name="CityDist.Azure" generation="1" functional="0" release="0" Id="7f1b33db-4637-41d1-8c63-bfc4dd5a38f1" dslVersion="1.2.0.0" xmlns="http://schemas.microsoft.com/dsltools/RDSM">
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
          <role name="CityDist" generation="1" functional="0" release="0" software="G:\MiniProjectTuesday\WebServiceWEBRoles\CityDist\CityDist\CityDist.Azure\csx\Release\roles\CityDist" entryPoint="base\x86\WaHostBootstrapper.exe" parameters="base\x86\WaIISHost.exe " memIndex="1792" hostingEnvironment="frontendadmin" hostingEnvironmentVersion="2">
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
    <implementation Id="2c469bec-8d0a-42ed-b593-3d7e95ab6e27" ref="Microsoft.RedDog.Contract\ServiceContract\CityDist.AzureContract@ServiceDefinition.build">
      <interfacereferences>
        <interfaceReference Id="14b9187a-32b6-4e7b-a92d-413474ff12fb" ref="Microsoft.RedDog.Contract\Interface\CityDist:Endpoint1@ServiceDefinition.build">
          <inPort>
            <inPortMoniker name="/CityDist.Azure/CityDist.AzureGroup/CityDist:Endpoint1" />
          </inPort>
        </interfaceReference>
      </interfacereferences>
    </implementation>
  </implements>
</serviceModel>