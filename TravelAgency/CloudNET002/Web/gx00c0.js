gx.evt.autoSkip=!1;gx.define("gx00c0",!1,function(){var n,t;this.ServerClass="gx00c0";this.PackageName="GeneXus.Programs";this.ServerFullClass="gx00c0.aspx";this.setObjectType("web");this.anyGridBaseTable=!0;this.hasEnterEvent=!0;this.skipOnEnter=!1;this.autoRefresh=!0;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.DSO="TravelAgency";this.SetStandaloneVars=function(){this.AV8pSuplierId=gx.fn.getIntegerValue("vPSUPLIERID",",")};this.e130l1_client=function(){return this.executeClientEvent(function(){this.clearMessages();gx.text.compare(gx.fn.getCtrlProperty("ADVANCEDCONTAINER","Class"),"AdvancedContainer")==0?(gx.fn.setCtrlProperty("ADVANCEDCONTAINER","Class","AdvancedContainer AdvancedContainerVisible"),gx.fn.setCtrlProperty("BTNTOGGLE","Class",gx.fn.getCtrlProperty("BTNTOGGLE","Class")+" BtnToggleActive")):(gx.fn.setCtrlProperty("ADVANCEDCONTAINER","Class","AdvancedContainer"),gx.fn.setCtrlProperty("BTNTOGGLE","Class","BtnToggle"));this.refreshOutputs([{av:"gx.fn.getCtrlProperty('ADVANCEDCONTAINER','Class')",ctrl:"ADVANCEDCONTAINER",prop:"Class"},{ctrl:"BTNTOGGLE",prop:"Class"}]);this.OnClientEventEnd()},arguments)};this.e110l1_client=function(){return this.executeClientEvent(function(){this.clearMessages();gx.text.compare(gx.fn.getCtrlProperty("SUPLIERIDFILTERCONTAINER","Class"),"AdvancedContainerItem")==0?(gx.fn.setCtrlProperty("SUPLIERIDFILTERCONTAINER","Class","AdvancedContainerItem AdvancedContainerItemExpanded"),gx.fn.setCtrlProperty("vCSUPLIERID","Visible",!0)):(gx.fn.setCtrlProperty("SUPLIERIDFILTERCONTAINER","Class","AdvancedContainerItem"),gx.fn.setCtrlProperty("vCSUPLIERID","Visible",!1));this.refreshOutputs([{av:"gx.fn.getCtrlProperty('SUPLIERIDFILTERCONTAINER','Class')",ctrl:"SUPLIERIDFILTERCONTAINER",prop:"Class"},{av:"gx.fn.getCtrlProperty('vCSUPLIERID','Visible')",ctrl:"vCSUPLIERID",prop:"Visible"}]);this.OnClientEventEnd()},arguments)};this.e120l1_client=function(){return this.executeClientEvent(function(){this.clearMessages();gx.text.compare(gx.fn.getCtrlProperty("SUPLIERNAMEFILTERCONTAINER","Class"),"AdvancedContainerItem")==0?(gx.fn.setCtrlProperty("SUPLIERNAMEFILTERCONTAINER","Class","AdvancedContainerItem AdvancedContainerItemExpanded"),gx.fn.setCtrlProperty("vCSUPLIERNAME","Visible",!0)):(gx.fn.setCtrlProperty("SUPLIERNAMEFILTERCONTAINER","Class","AdvancedContainerItem"),gx.fn.setCtrlProperty("vCSUPLIERNAME","Visible",!1));this.refreshOutputs([{av:"gx.fn.getCtrlProperty('SUPLIERNAMEFILTERCONTAINER','Class')",ctrl:"SUPLIERNAMEFILTERCONTAINER",prop:"Class"},{av:"gx.fn.getCtrlProperty('vCSUPLIERNAME','Visible')",ctrl:"vCSUPLIERNAME",prop:"Visible"}]);this.OnClientEventEnd()},arguments)};this.e160l2_client=function(){return this.executeServerEvent("ENTER",!0,arguments[0],!1,!1)};this.e170l1_client=function(){return this.executeServerEvent("CANCEL",!0,null,!1,!1)};this.GXValidFnc=[];n=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,35,36,37,38,39,40];this.GXLastCtrlId=40;this.Grid1Container=new gx.grid.grid(this,2,"WbpLvl2",34,"Grid1","Grid1","Grid1Container",this.CmpContext,this.IsMasterPage,"gx00c0",[],!1,1,!1,!0,10,!0,!1,!1,"",0,"px",0,"px","New row",!0,!1,!1,null,null,!1,"",!1,[1,1,1,1],!1,0,!0,!1);t=this.Grid1Container;t.addBitmap("&Linkselection","vLINKSELECTION",35,0,"px",17,"px",null,"","","SelectionAttribute","WWActionColumn");t.addSingleLineEdit(37,36,"SUPLIERID","Id","","SuplierId","int",0,"px",4,4,"end",null,[],37,"SuplierId",!0,0,!1,!1,"Attribute",0,"WWColumn");t.addSingleLineEdit(38,37,"SUPLIERNAME","Name","","SuplierName","char",0,"px",50,50,"start",null,[],38,"SuplierName",!0,0,!1,!1,"DescriptionAttribute",0,"WWColumn");this.Grid1Container.emptyText="";this.setGrid(t);n[2]={id:2,fld:"",grid:0};n[3]={id:3,fld:"MAIN",grid:0};n[4]={id:4,fld:"",grid:0};n[5]={id:5,fld:"",grid:0};n[6]={id:6,fld:"ADVANCEDCONTAINER",grid:0};n[7]={id:7,fld:"",grid:0};n[8]={id:8,fld:"",grid:0};n[9]={id:9,fld:"SUPLIERIDFILTERCONTAINER",grid:0};n[10]={id:10,fld:"",grid:0};n[11]={id:11,fld:"",grid:0};n[12]={id:12,fld:"LBLSUPLIERIDFILTER",format:1,grid:0,evt:"e110l1_client",ctrltype:"textblock"};n[13]={id:13,fld:"",grid:0};n[14]={id:14,fld:"",grid:0};n[15]={id:15,fld:"",grid:0};n[16]={id:16,lvl:0,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[this.Grid1Container],fld:"vCSUPLIERID",fmt:0,gxz:"ZV6cSuplierId",gxold:"OV6cSuplierId",gxvar:"AV6cSuplierId",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV6cSuplierId=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.ZV6cSuplierId=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("vCSUPLIERID",gx.O.AV6cSuplierId,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV6cSuplierId=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("vCSUPLIERID",",")},nac:gx.falseFn};n[17]={id:17,fld:"",grid:0};n[18]={id:18,fld:"",grid:0};n[19]={id:19,fld:"SUPLIERNAMEFILTERCONTAINER",grid:0};n[20]={id:20,fld:"",grid:0};n[21]={id:21,fld:"",grid:0};n[22]={id:22,fld:"LBLSUPLIERNAMEFILTER",format:1,grid:0,evt:"e120l1_client",ctrltype:"textblock"};n[23]={id:23,fld:"",grid:0};n[24]={id:24,fld:"",grid:0};n[25]={id:25,fld:"",grid:0};n[26]={id:26,lvl:0,type:"char",len:50,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[this.Grid1Container],fld:"vCSUPLIERNAME",fmt:0,gxz:"ZV7cSuplierName",gxold:"OV7cSuplierName",gxvar:"AV7cSuplierName",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV7cSuplierName=n)},v2z:function(n){n!==undefined&&(gx.O.ZV7cSuplierName=n)},v2c:function(){gx.fn.setControlValue("vCSUPLIERNAME",gx.O.AV7cSuplierName,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV7cSuplierName=this.val())},val:function(){return gx.fn.getControlValue("vCSUPLIERNAME")},nac:gx.falseFn};n[27]={id:27,fld:"",grid:0};n[28]={id:28,fld:"GRIDTABLE",grid:0};n[29]={id:29,fld:"",grid:0};n[30]={id:30,fld:"",grid:0};n[31]={id:31,fld:"BTNTOGGLE",grid:0,evt:"e130l1_client"};n[32]={id:32,fld:"",grid:0};n[33]={id:33,fld:"",grid:0};n[35]={id:35,lvl:2,type:"bits",len:1024,dec:0,sign:!1,ro:1,isacc:0,grid:34,gxgrid:this.Grid1Container,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vLINKSELECTION",fmt:0,gxz:"ZV5LinkSelection",gxold:"OV5LinkSelection",gxvar:"AV5LinkSelection",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.AV5LinkSelection=n)},v2z:function(n){n!==undefined&&(gx.O.ZV5LinkSelection=n)},v2c:function(n){gx.fn.setGridMultimediaValue("vLINKSELECTION",n||gx.fn.currentGridRowImpl(34),gx.O.AV5LinkSelection,gx.O.AV10Linkselection_GXI)},c2v:function(n){gx.O.AV10Linkselection_GXI=this.val_GXI();this.val(n)!==undefined&&(gx.O.AV5LinkSelection=this.val(n))},val:function(n){return gx.fn.getGridControlValue("vLINKSELECTION",n||gx.fn.currentGridRowImpl(34))},val_GXI:function(n){return gx.fn.getGridControlValue("vLINKSELECTION_GXI",n||gx.fn.currentGridRowImpl(34))},gxvar_GXI:"AV10Linkselection_GXI",nac:gx.falseFn};n[36]={id:36,lvl:2,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:1,isacc:0,grid:34,gxgrid:this.Grid1Container,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"SUPLIERID",fmt:0,gxz:"Z37SuplierId",gxold:"O37SuplierId",gxvar:"A37SuplierId",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A37SuplierId=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z37SuplierId=gx.num.intval(n))},v2c:function(n){gx.fn.setGridControlValue("SUPLIERID",n||gx.fn.currentGridRowImpl(34),gx.O.A37SuplierId,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A37SuplierId=gx.num.intval(this.val(n)))},val:function(n){return gx.fn.getGridIntegerValue("SUPLIERID",n||gx.fn.currentGridRowImpl(34),",")},nac:gx.falseFn};n[37]={id:37,lvl:2,type:"char",len:50,dec:0,sign:!1,ro:1,isacc:0,grid:34,gxgrid:this.Grid1Container,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"SUPLIERNAME",fmt:0,gxz:"Z38SuplierName",gxold:"O38SuplierName",gxvar:"A38SuplierName",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.A38SuplierName=n)},v2z:function(n){n!==undefined&&(gx.O.Z38SuplierName=n)},v2c:function(n){gx.fn.setGridControlValue("SUPLIERNAME",n||gx.fn.currentGridRowImpl(34),gx.O.A38SuplierName,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A38SuplierName=this.val(n))},val:function(n){return gx.fn.getGridControlValue("SUPLIERNAME",n||gx.fn.currentGridRowImpl(34))},nac:gx.falseFn};n[38]={id:38,fld:"",grid:0};n[39]={id:39,fld:"",grid:0};n[40]={id:40,fld:"BTN_CANCEL",grid:0,evt:"e170l1_client"};this.AV6cSuplierId=0;this.ZV6cSuplierId=0;this.OV6cSuplierId=0;this.AV7cSuplierName="";this.ZV7cSuplierName="";this.OV7cSuplierName="";this.ZV5LinkSelection="";this.OV5LinkSelection="";this.Z37SuplierId=0;this.O37SuplierId=0;this.Z38SuplierName="";this.O38SuplierName="";this.AV6cSuplierId=0;this.AV7cSuplierName="";this.AV8pSuplierId=0;this.AV5LinkSelection="";this.A37SuplierId=0;this.A38SuplierName="";this.Events={e160l2_client:["ENTER",!0],e170l1_client:["CANCEL",!0],e130l1_client:["'TOGGLE'",!1],e110l1_client:["LBLSUPLIERIDFILTER.CLICK",!1],e120l1_client:["LBLSUPLIERNAMEFILTER.CLICK",!1]};this.EvtParms.REFRESH=[[{av:"GRID1_nFirstRecordOnPage"},{av:"GRID1_nEOF"},{av:"",ctrl:"GRID1",prop:"Rows"},{av:"AV6cSuplierId",fld:"vCSUPLIERID",pic:"ZZZ9"},{av:"AV7cSuplierName",fld:"vCSUPLIERNAME"}],[]];this.EvtParms["'TOGGLE'"]=[[{av:"gx.fn.getCtrlProperty('ADVANCEDCONTAINER','Class')",ctrl:"ADVANCEDCONTAINER",prop:"Class"},{ctrl:"BTNTOGGLE",prop:"Class"}],[{av:"gx.fn.getCtrlProperty('ADVANCEDCONTAINER','Class')",ctrl:"ADVANCEDCONTAINER",prop:"Class"},{ctrl:"BTNTOGGLE",prop:"Class"}]];this.EvtParms["LBLSUPLIERIDFILTER.CLICK"]=[[{av:"gx.fn.getCtrlProperty('SUPLIERIDFILTERCONTAINER','Class')",ctrl:"SUPLIERIDFILTERCONTAINER",prop:"Class"}],[{av:"gx.fn.getCtrlProperty('SUPLIERIDFILTERCONTAINER','Class')",ctrl:"SUPLIERIDFILTERCONTAINER",prop:"Class"},{av:"gx.fn.getCtrlProperty('vCSUPLIERID','Visible')",ctrl:"vCSUPLIERID",prop:"Visible"}]];this.EvtParms["LBLSUPLIERNAMEFILTER.CLICK"]=[[{av:"gx.fn.getCtrlProperty('SUPLIERNAMEFILTERCONTAINER','Class')",ctrl:"SUPLIERNAMEFILTERCONTAINER",prop:"Class"}],[{av:"gx.fn.getCtrlProperty('SUPLIERNAMEFILTERCONTAINER','Class')",ctrl:"SUPLIERNAMEFILTERCONTAINER",prop:"Class"},{av:"gx.fn.getCtrlProperty('vCSUPLIERNAME','Visible')",ctrl:"vCSUPLIERNAME",prop:"Visible"}]];this.EvtParms.ENTER=[[{av:"A37SuplierId",fld:"SUPLIERID",pic:"ZZZ9",hsh:!0}],[{av:"AV8pSuplierId",fld:"vPSUPLIERID",pic:"ZZZ9"}]];this.EvtParms.GRID1_FIRSTPAGE=[[{av:"GRID1_nFirstRecordOnPage"},{av:"GRID1_nEOF"},{av:"",ctrl:"GRID1",prop:"Rows"},{av:"AV6cSuplierId",fld:"vCSUPLIERID",pic:"ZZZ9"},{av:"AV7cSuplierName",fld:"vCSUPLIERNAME"}],[]];this.EvtParms.GRID1_PREVPAGE=[[{av:"GRID1_nFirstRecordOnPage"},{av:"GRID1_nEOF"},{av:"",ctrl:"GRID1",prop:"Rows"},{av:"AV6cSuplierId",fld:"vCSUPLIERID",pic:"ZZZ9"},{av:"AV7cSuplierName",fld:"vCSUPLIERNAME"}],[]];this.EvtParms.GRID1_NEXTPAGE=[[{av:"GRID1_nFirstRecordOnPage"},{av:"GRID1_nEOF"},{av:"",ctrl:"GRID1",prop:"Rows"},{av:"AV6cSuplierId",fld:"vCSUPLIERID",pic:"ZZZ9"},{av:"AV7cSuplierName",fld:"vCSUPLIERNAME"}],[]];this.EvtParms.GRID1_LASTPAGE=[[{av:"GRID1_nFirstRecordOnPage"},{av:"GRID1_nEOF"},{av:"",ctrl:"GRID1",prop:"Rows"},{av:"AV6cSuplierId",fld:"vCSUPLIERID",pic:"ZZZ9"},{av:"AV7cSuplierName",fld:"vCSUPLIERNAME"}],[]];this.setVCMap("AV8pSuplierId","vPSUPLIERID",0,"int",4,0);t.addRefreshingParm({rfrProp:"Rows",gxGrid:"Grid1"});t.addRefreshingVar(this.GXValidFnc[16]);t.addRefreshingVar(this.GXValidFnc[26]);t.addRefreshingParm(this.GXValidFnc[16]);t.addRefreshingParm(this.GXValidFnc[26]);this.Initialize()});gx.wi(function(){gx.createParentObj(this.gx00c0)})