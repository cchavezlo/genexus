gx.evt.autoSkip=!1;gx.define("gx0090",!1,function(){var n,t;this.ServerClass="gx0090";this.PackageName="GeneXus.Programs";this.ServerFullClass="gx0090.aspx";this.setObjectType("web");this.anyGridBaseTable=!0;this.hasEnterEvent=!0;this.skipOnEnter=!1;this.autoRefresh=!0;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.DSO="TravelAgency";this.SetStandaloneVars=function(){this.AV9pAirlineID=gx.fn.getIntegerValue("vPAIRLINEID",",")};this.e140i1_client=function(){return this.executeClientEvent(function(){this.clearMessages();gx.text.compare(gx.fn.getCtrlProperty("ADVANCEDCONTAINER","Class"),"AdvancedContainer")==0?(gx.fn.setCtrlProperty("ADVANCEDCONTAINER","Class","AdvancedContainer AdvancedContainerVisible"),gx.fn.setCtrlProperty("BTNTOGGLE","Class",gx.fn.getCtrlProperty("BTNTOGGLE","Class")+" BtnToggleActive")):(gx.fn.setCtrlProperty("ADVANCEDCONTAINER","Class","AdvancedContainer"),gx.fn.setCtrlProperty("BTNTOGGLE","Class","BtnToggle"));this.refreshOutputs([{av:"gx.fn.getCtrlProperty('ADVANCEDCONTAINER','Class')",ctrl:"ADVANCEDCONTAINER",prop:"Class"},{ctrl:"BTNTOGGLE",prop:"Class"}]);this.OnClientEventEnd()},arguments)};this.e110i1_client=function(){return this.executeClientEvent(function(){this.clearMessages();gx.text.compare(gx.fn.getCtrlProperty("AIRLINEIDFILTERCONTAINER","Class"),"AdvancedContainerItem")==0?(gx.fn.setCtrlProperty("AIRLINEIDFILTERCONTAINER","Class","AdvancedContainerItem AdvancedContainerItemExpanded"),gx.fn.setCtrlProperty("vCAIRLINEID","Visible",!0)):(gx.fn.setCtrlProperty("AIRLINEIDFILTERCONTAINER","Class","AdvancedContainerItem"),gx.fn.setCtrlProperty("vCAIRLINEID","Visible",!1));this.refreshOutputs([{av:"gx.fn.getCtrlProperty('AIRLINEIDFILTERCONTAINER','Class')",ctrl:"AIRLINEIDFILTERCONTAINER",prop:"Class"},{av:"gx.fn.getCtrlProperty('vCAIRLINEID','Visible')",ctrl:"vCAIRLINEID",prop:"Visible"}]);this.OnClientEventEnd()},arguments)};this.e120i1_client=function(){return this.executeClientEvent(function(){this.clearMessages();gx.text.compare(gx.fn.getCtrlProperty("AIRLINENAMEFILTERCONTAINER","Class"),"AdvancedContainerItem")==0?(gx.fn.setCtrlProperty("AIRLINENAMEFILTERCONTAINER","Class","AdvancedContainerItem AdvancedContainerItemExpanded"),gx.fn.setCtrlProperty("vCAIRLINENAME","Visible",!0)):(gx.fn.setCtrlProperty("AIRLINENAMEFILTERCONTAINER","Class","AdvancedContainerItem"),gx.fn.setCtrlProperty("vCAIRLINENAME","Visible",!1));this.refreshOutputs([{av:"gx.fn.getCtrlProperty('AIRLINENAMEFILTERCONTAINER','Class')",ctrl:"AIRLINENAMEFILTERCONTAINER",prop:"Class"},{av:"gx.fn.getCtrlProperty('vCAIRLINENAME','Visible')",ctrl:"vCAIRLINENAME",prop:"Visible"}]);this.OnClientEventEnd()},arguments)};this.e130i1_client=function(){return this.executeClientEvent(function(){this.clearMessages();gx.text.compare(gx.fn.getCtrlProperty("AIRLINEDISCOUNTPERCENTAGEFILTERCONTAINER","Class"),"AdvancedContainerItem")==0?(gx.fn.setCtrlProperty("AIRLINEDISCOUNTPERCENTAGEFILTERCONTAINER","Class","AdvancedContainerItem AdvancedContainerItemExpanded"),gx.fn.setCtrlProperty("vCAIRLINEDISCOUNTPERCENTAGE","Visible",!0)):(gx.fn.setCtrlProperty("AIRLINEDISCOUNTPERCENTAGEFILTERCONTAINER","Class","AdvancedContainerItem"),gx.fn.setCtrlProperty("vCAIRLINEDISCOUNTPERCENTAGE","Visible",!1));this.refreshOutputs([{av:"gx.fn.getCtrlProperty('AIRLINEDISCOUNTPERCENTAGEFILTERCONTAINER','Class')",ctrl:"AIRLINEDISCOUNTPERCENTAGEFILTERCONTAINER",prop:"Class"},{av:"gx.fn.getCtrlProperty('vCAIRLINEDISCOUNTPERCENTAGE','Visible')",ctrl:"vCAIRLINEDISCOUNTPERCENTAGE",prop:"Visible"}]);this.OnClientEventEnd()},arguments)};this.e170i2_client=function(){return this.executeServerEvent("ENTER",!0,arguments[0],!1,!1)};this.e180i1_client=function(){return this.executeServerEvent("CANCEL",!0,null,!1,!1)};this.GXValidFnc=[];n=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,45,46,47,48,49,50,51];this.GXLastCtrlId=51;this.Grid1Container=new gx.grid.grid(this,2,"WbpLvl2",44,"Grid1","Grid1","Grid1Container",this.CmpContext,this.IsMasterPage,"gx0090",[],!1,1,!1,!0,10,!0,!1,!1,"",0,"px",0,"px","New row",!0,!1,!1,null,null,!1,"",!1,[1,1,1,1],!1,0,!0,!1);t=this.Grid1Container;t.addBitmap("&Linkselection","vLINKSELECTION",45,0,"px",17,"px",null,"","","SelectionAttribute","WWActionColumn");t.addSingleLineEdit(30,46,"AIRLINEID","ID","","AirlineID","int",0,"px",4,4,"end",null,[],30,"AirlineID",!0,0,!1,!1,"Attribute",0,"WWColumn");t.addSingleLineEdit(31,47,"AIRLINENAME","Name","","AirlineName","char",0,"px",50,50,"start",null,[],31,"AirlineName",!0,0,!1,!1,"DescriptionAttribute",0,"WWColumn");t.addSingleLineEdit(32,48,"AIRLINEDISCOUNTPERCENTAGE","Discount Percentage","","AirlineDiscountPercentage","int",0,"px",3,3,"end",null,[],32,"AirlineDiscountPercentage",!0,0,!1,!1,"Attribute",0,"WWColumn OptionalColumn");this.Grid1Container.emptyText="";this.setGrid(t);n[2]={id:2,fld:"",grid:0};n[3]={id:3,fld:"MAIN",grid:0};n[4]={id:4,fld:"",grid:0};n[5]={id:5,fld:"",grid:0};n[6]={id:6,fld:"ADVANCEDCONTAINER",grid:0};n[7]={id:7,fld:"",grid:0};n[8]={id:8,fld:"",grid:0};n[9]={id:9,fld:"AIRLINEIDFILTERCONTAINER",grid:0};n[10]={id:10,fld:"",grid:0};n[11]={id:11,fld:"",grid:0};n[12]={id:12,fld:"LBLAIRLINEIDFILTER",format:1,grid:0,evt:"e110i1_client",ctrltype:"textblock"};n[13]={id:13,fld:"",grid:0};n[14]={id:14,fld:"",grid:0};n[15]={id:15,fld:"",grid:0};n[16]={id:16,lvl:0,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[this.Grid1Container],fld:"vCAIRLINEID",fmt:0,gxz:"ZV6cAirlineID",gxold:"OV6cAirlineID",gxvar:"AV6cAirlineID",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV6cAirlineID=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.ZV6cAirlineID=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("vCAIRLINEID",gx.O.AV6cAirlineID,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV6cAirlineID=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("vCAIRLINEID",",")},nac:gx.falseFn};n[17]={id:17,fld:"",grid:0};n[18]={id:18,fld:"",grid:0};n[19]={id:19,fld:"AIRLINENAMEFILTERCONTAINER",grid:0};n[20]={id:20,fld:"",grid:0};n[21]={id:21,fld:"",grid:0};n[22]={id:22,fld:"LBLAIRLINENAMEFILTER",format:1,grid:0,evt:"e120i1_client",ctrltype:"textblock"};n[23]={id:23,fld:"",grid:0};n[24]={id:24,fld:"",grid:0};n[25]={id:25,fld:"",grid:0};n[26]={id:26,lvl:0,type:"char",len:50,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[this.Grid1Container],fld:"vCAIRLINENAME",fmt:0,gxz:"ZV7cAirlineName",gxold:"OV7cAirlineName",gxvar:"AV7cAirlineName",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV7cAirlineName=n)},v2z:function(n){n!==undefined&&(gx.O.ZV7cAirlineName=n)},v2c:function(){gx.fn.setControlValue("vCAIRLINENAME",gx.O.AV7cAirlineName,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV7cAirlineName=this.val())},val:function(){return gx.fn.getControlValue("vCAIRLINENAME")},nac:gx.falseFn};n[27]={id:27,fld:"",grid:0};n[28]={id:28,fld:"",grid:0};n[29]={id:29,fld:"AIRLINEDISCOUNTPERCENTAGEFILTERCONTAINER",grid:0};n[30]={id:30,fld:"",grid:0};n[31]={id:31,fld:"",grid:0};n[32]={id:32,fld:"LBLAIRLINEDISCOUNTPERCENTAGEFILTER",format:1,grid:0,evt:"e130i1_client",ctrltype:"textblock"};n[33]={id:33,fld:"",grid:0};n[34]={id:34,fld:"",grid:0};n[35]={id:35,fld:"",grid:0};n[36]={id:36,lvl:0,type:"int",len:3,dec:0,sign:!1,pic:"ZZ9",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[this.Grid1Container],fld:"vCAIRLINEDISCOUNTPERCENTAGE",fmt:0,gxz:"ZV8cAirlineDiscountPercentage",gxold:"OV8cAirlineDiscountPercentage",gxvar:"AV8cAirlineDiscountPercentage",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV8cAirlineDiscountPercentage=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.ZV8cAirlineDiscountPercentage=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("vCAIRLINEDISCOUNTPERCENTAGE",gx.O.AV8cAirlineDiscountPercentage,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV8cAirlineDiscountPercentage=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("vCAIRLINEDISCOUNTPERCENTAGE",",")},nac:gx.falseFn};n[37]={id:37,fld:"",grid:0};n[38]={id:38,fld:"GRIDTABLE",grid:0};n[39]={id:39,fld:"",grid:0};n[40]={id:40,fld:"",grid:0};n[41]={id:41,fld:"BTNTOGGLE",grid:0,evt:"e140i1_client"};n[42]={id:42,fld:"",grid:0};n[43]={id:43,fld:"",grid:0};n[45]={id:45,lvl:2,type:"bits",len:1024,dec:0,sign:!1,ro:1,isacc:0,grid:44,gxgrid:this.Grid1Container,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vLINKSELECTION",fmt:0,gxz:"ZV5LinkSelection",gxold:"OV5LinkSelection",gxvar:"AV5LinkSelection",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.AV5LinkSelection=n)},v2z:function(n){n!==undefined&&(gx.O.ZV5LinkSelection=n)},v2c:function(n){gx.fn.setGridMultimediaValue("vLINKSELECTION",n||gx.fn.currentGridRowImpl(44),gx.O.AV5LinkSelection,gx.O.AV11Linkselection_GXI)},c2v:function(n){gx.O.AV11Linkselection_GXI=this.val_GXI();this.val(n)!==undefined&&(gx.O.AV5LinkSelection=this.val(n))},val:function(n){return gx.fn.getGridControlValue("vLINKSELECTION",n||gx.fn.currentGridRowImpl(44))},val_GXI:function(n){return gx.fn.getGridControlValue("vLINKSELECTION_GXI",n||gx.fn.currentGridRowImpl(44))},gxvar_GXI:"AV11Linkselection_GXI",nac:gx.falseFn};n[46]={id:46,lvl:2,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:1,isacc:0,grid:44,gxgrid:this.Grid1Container,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"AIRLINEID",fmt:0,gxz:"Z30AirlineID",gxold:"O30AirlineID",gxvar:"A30AirlineID",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A30AirlineID=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z30AirlineID=gx.num.intval(n))},v2c:function(n){gx.fn.setGridControlValue("AIRLINEID",n||gx.fn.currentGridRowImpl(44),gx.O.A30AirlineID,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A30AirlineID=gx.num.intval(this.val(n)))},val:function(n){return gx.fn.getGridIntegerValue("AIRLINEID",n||gx.fn.currentGridRowImpl(44),",")},nac:gx.falseFn};n[47]={id:47,lvl:2,type:"char",len:50,dec:0,sign:!1,ro:1,isacc:0,grid:44,gxgrid:this.Grid1Container,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"AIRLINENAME",fmt:0,gxz:"Z31AirlineName",gxold:"O31AirlineName",gxvar:"A31AirlineName",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.A31AirlineName=n)},v2z:function(n){n!==undefined&&(gx.O.Z31AirlineName=n)},v2c:function(n){gx.fn.setGridControlValue("AIRLINENAME",n||gx.fn.currentGridRowImpl(44),gx.O.A31AirlineName,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A31AirlineName=this.val(n))},val:function(n){return gx.fn.getGridControlValue("AIRLINENAME",n||gx.fn.currentGridRowImpl(44))},nac:gx.falseFn};n[48]={id:48,lvl:2,type:"int",len:3,dec:0,sign:!1,pic:"ZZ9",ro:1,isacc:0,grid:44,gxgrid:this.Grid1Container,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"AIRLINEDISCOUNTPERCENTAGE",fmt:0,gxz:"Z32AirlineDiscountPercentage",gxold:"O32AirlineDiscountPercentage",gxvar:"A32AirlineDiscountPercentage",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A32AirlineDiscountPercentage=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z32AirlineDiscountPercentage=gx.num.intval(n))},v2c:function(n){gx.fn.setGridControlValue("AIRLINEDISCOUNTPERCENTAGE",n||gx.fn.currentGridRowImpl(44),gx.O.A32AirlineDiscountPercentage,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A32AirlineDiscountPercentage=gx.num.intval(this.val(n)))},val:function(n){return gx.fn.getGridIntegerValue("AIRLINEDISCOUNTPERCENTAGE",n||gx.fn.currentGridRowImpl(44),",")},nac:gx.falseFn};n[49]={id:49,fld:"",grid:0};n[50]={id:50,fld:"",grid:0};n[51]={id:51,fld:"BTN_CANCEL",grid:0,evt:"e180i1_client"};this.AV6cAirlineID=0;this.ZV6cAirlineID=0;this.OV6cAirlineID=0;this.AV7cAirlineName="";this.ZV7cAirlineName="";this.OV7cAirlineName="";this.AV8cAirlineDiscountPercentage=0;this.ZV8cAirlineDiscountPercentage=0;this.OV8cAirlineDiscountPercentage=0;this.ZV5LinkSelection="";this.OV5LinkSelection="";this.Z30AirlineID=0;this.O30AirlineID=0;this.Z31AirlineName="";this.O31AirlineName="";this.Z32AirlineDiscountPercentage=0;this.O32AirlineDiscountPercentage=0;this.AV6cAirlineID=0;this.AV7cAirlineName="";this.AV8cAirlineDiscountPercentage=0;this.AV9pAirlineID=0;this.AV5LinkSelection="";this.A30AirlineID=0;this.A31AirlineName="";this.A32AirlineDiscountPercentage=0;this.Events={e170i2_client:["ENTER",!0],e180i1_client:["CANCEL",!0],e140i1_client:["'TOGGLE'",!1],e110i1_client:["LBLAIRLINEIDFILTER.CLICK",!1],e120i1_client:["LBLAIRLINENAMEFILTER.CLICK",!1],e130i1_client:["LBLAIRLINEDISCOUNTPERCENTAGEFILTER.CLICK",!1]};this.EvtParms.REFRESH=[[{av:"GRID1_nFirstRecordOnPage"},{av:"GRID1_nEOF"},{av:"",ctrl:"GRID1",prop:"Rows"},{av:"AV6cAirlineID",fld:"vCAIRLINEID",pic:"ZZZ9"},{av:"AV7cAirlineName",fld:"vCAIRLINENAME"},{av:"AV8cAirlineDiscountPercentage",fld:"vCAIRLINEDISCOUNTPERCENTAGE",pic:"ZZ9"}],[]];this.EvtParms["'TOGGLE'"]=[[{av:"gx.fn.getCtrlProperty('ADVANCEDCONTAINER','Class')",ctrl:"ADVANCEDCONTAINER",prop:"Class"},{ctrl:"BTNTOGGLE",prop:"Class"}],[{av:"gx.fn.getCtrlProperty('ADVANCEDCONTAINER','Class')",ctrl:"ADVANCEDCONTAINER",prop:"Class"},{ctrl:"BTNTOGGLE",prop:"Class"}]];this.EvtParms["LBLAIRLINEIDFILTER.CLICK"]=[[{av:"gx.fn.getCtrlProperty('AIRLINEIDFILTERCONTAINER','Class')",ctrl:"AIRLINEIDFILTERCONTAINER",prop:"Class"}],[{av:"gx.fn.getCtrlProperty('AIRLINEIDFILTERCONTAINER','Class')",ctrl:"AIRLINEIDFILTERCONTAINER",prop:"Class"},{av:"gx.fn.getCtrlProperty('vCAIRLINEID','Visible')",ctrl:"vCAIRLINEID",prop:"Visible"}]];this.EvtParms["LBLAIRLINENAMEFILTER.CLICK"]=[[{av:"gx.fn.getCtrlProperty('AIRLINENAMEFILTERCONTAINER','Class')",ctrl:"AIRLINENAMEFILTERCONTAINER",prop:"Class"}],[{av:"gx.fn.getCtrlProperty('AIRLINENAMEFILTERCONTAINER','Class')",ctrl:"AIRLINENAMEFILTERCONTAINER",prop:"Class"},{av:"gx.fn.getCtrlProperty('vCAIRLINENAME','Visible')",ctrl:"vCAIRLINENAME",prop:"Visible"}]];this.EvtParms["LBLAIRLINEDISCOUNTPERCENTAGEFILTER.CLICK"]=[[{av:"gx.fn.getCtrlProperty('AIRLINEDISCOUNTPERCENTAGEFILTERCONTAINER','Class')",ctrl:"AIRLINEDISCOUNTPERCENTAGEFILTERCONTAINER",prop:"Class"}],[{av:"gx.fn.getCtrlProperty('AIRLINEDISCOUNTPERCENTAGEFILTERCONTAINER','Class')",ctrl:"AIRLINEDISCOUNTPERCENTAGEFILTERCONTAINER",prop:"Class"},{av:"gx.fn.getCtrlProperty('vCAIRLINEDISCOUNTPERCENTAGE','Visible')",ctrl:"vCAIRLINEDISCOUNTPERCENTAGE",prop:"Visible"}]];this.EvtParms.ENTER=[[{av:"A30AirlineID",fld:"AIRLINEID",pic:"ZZZ9",hsh:!0}],[{av:"AV9pAirlineID",fld:"vPAIRLINEID",pic:"ZZZ9"}]];this.EvtParms.GRID1_FIRSTPAGE=[[{av:"GRID1_nFirstRecordOnPage"},{av:"GRID1_nEOF"},{av:"",ctrl:"GRID1",prop:"Rows"},{av:"AV6cAirlineID",fld:"vCAIRLINEID",pic:"ZZZ9"},{av:"AV7cAirlineName",fld:"vCAIRLINENAME"},{av:"AV8cAirlineDiscountPercentage",fld:"vCAIRLINEDISCOUNTPERCENTAGE",pic:"ZZ9"}],[]];this.EvtParms.GRID1_PREVPAGE=[[{av:"GRID1_nFirstRecordOnPage"},{av:"GRID1_nEOF"},{av:"",ctrl:"GRID1",prop:"Rows"},{av:"AV6cAirlineID",fld:"vCAIRLINEID",pic:"ZZZ9"},{av:"AV7cAirlineName",fld:"vCAIRLINENAME"},{av:"AV8cAirlineDiscountPercentage",fld:"vCAIRLINEDISCOUNTPERCENTAGE",pic:"ZZ9"}],[]];this.EvtParms.GRID1_NEXTPAGE=[[{av:"GRID1_nFirstRecordOnPage"},{av:"GRID1_nEOF"},{av:"",ctrl:"GRID1",prop:"Rows"},{av:"AV6cAirlineID",fld:"vCAIRLINEID",pic:"ZZZ9"},{av:"AV7cAirlineName",fld:"vCAIRLINENAME"},{av:"AV8cAirlineDiscountPercentage",fld:"vCAIRLINEDISCOUNTPERCENTAGE",pic:"ZZ9"}],[]];this.EvtParms.GRID1_LASTPAGE=[[{av:"GRID1_nFirstRecordOnPage"},{av:"GRID1_nEOF"},{av:"",ctrl:"GRID1",prop:"Rows"},{av:"AV6cAirlineID",fld:"vCAIRLINEID",pic:"ZZZ9"},{av:"AV7cAirlineName",fld:"vCAIRLINENAME"},{av:"AV8cAirlineDiscountPercentage",fld:"vCAIRLINEDISCOUNTPERCENTAGE",pic:"ZZ9"}],[]];this.setVCMap("AV9pAirlineID","vPAIRLINEID",0,"int",4,0);t.addRefreshingParm({rfrProp:"Rows",gxGrid:"Grid1"});t.addRefreshingVar(this.GXValidFnc[16]);t.addRefreshingVar(this.GXValidFnc[26]);t.addRefreshingVar(this.GXValidFnc[36]);t.addRefreshingParm(this.GXValidFnc[16]);t.addRefreshingParm(this.GXValidFnc[26]);t.addRefreshingParm(this.GXValidFnc[36]);this.Initialize()});gx.wi(function(){gx.createParentObj(this.gx0090)})