SolrNetLight-Samples
====================

Solr schema.xml file extract :

	<!-- id-->
	<field name="id" type="long" indexed="true" stored="true" required="true" multiValued="false" /> 
	
	<!-- firstName-->
	<field name="firstName" type="string" indexed="true" stored="true"/>
	
	<!-- lastName -->
	<field name="lastName" type="string" indexed="true" stored="true"/>
	
	<!-- roles -->
	<field name="roles" type="string" indexed="true" stored="true" multiValued="true"/>
	
	<!-- phone_* -->
	<dynamicField name="phone_*" type="text_general" indexed="true" stored="true"/>
	