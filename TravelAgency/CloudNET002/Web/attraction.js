gx.evt.autoSkip=!1;gx.define("attraction",!1,function(){this.ServerClass="attraction";this.PackageName="GeneXus.Programs";this.ServerFullClass="attraction.aspx";this.setObjectType("trn");this.hasEnterEvent=!0;this.skipOnEnter=!1;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.DSO="TravelAgency";this.SetStandaloneVars=function(){this.AV7AttractionId=gx.fn.getIntegerValue("vATTRACTIONID",",");this.AV11Insert_CountryId=gx.fn.getIntegerValue("vINSERT_COUNTRYID",",");this.AV12Insert_CategoryId=gx.fn.getIntegerValue("vINSERT_CATEGORYID",",");this.AV13Insert_CityId=gx.fn.getIntegerValue("vINSERT_CITYID",",");this.A40000AttractionFoto_GXI=gx.fn.getControlValue("ATTRACTIONFOTO_GXI");this.AV16Pgmname=gx.fn.getControlValue("vPGMNAME");this.Gx_mode=gx.fn.getControlValue("vMODE");this.AV9TrnContext=gx.fn.getControlValue("vTRNCONTEXT")};this.Valid_Attractionid=function(){return this.validCliEvt("Valid_Attractionid",0,function(){try{var n=gx.util.balloon.getNew("ATTRACTIONID");this.AnyError=0}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.Valid_Attractionname=function(){return this.validSrvEvt("Valid_Attractionname",0).then(function(n){return n}.closure(this))};this.Valid_Countryid=function(){return this.validSrvEvt("Valid_Countryid",0).then(function(n){return n}.closure(this))};this.Valid_Categoryid=function(){return this.validSrvEvt("Valid_Categoryid",0).then(function(n){return n}.closure(this))};this.Valid_Cityid=function(){return this.validSrvEvt("Valid_Cityid",0).then(function(n){return n}.closure(this))};this.e12022_client=function(){return this.executeServerEvent("AFTER TRN",!0,null,!1,!1)};this.e13022_client=function(){return this.executeServerEvent("ENTER",!0,null,!1,!1)};this.e14022_client=function(){return this.executeServerEvent("CANCEL",!0,null,!1,!1)};this.GXValidFnc=[];var n=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,9,10,11,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49,50,51,52,53,54,55,56,57,58,59,60,61,62,63,64,65,66,67,68,69,70,71,72,73,74,75,76,77,78,79,80,81,82,83,84,85,86];this.GXLastCtrlId=86;n[2]={id:2,fld:"",grid:0};n[3]={id:3,fld:"MAINTABLE",grid:0};n[4]={id:4,fld:"",grid:0};n[5]={id:5,fld:"",grid:0};n[6]={id:6,fld:"TITLECONTAINER",grid:0};n[7]={id:7,fld:"",grid:0};n[8]={id:8,fld:"",grid:0};n[9]={id:9,fld:"TITLE",format:0,grid:0,ctrltype:"textblock"};n[10]={id:10,fld:"",grid:0};n[11]={id:11,fld:"",grid:0};n[13]={id:13,fld:"",grid:0};n[14]={id:14,fld:"",grid:0};n[15]={id:15,fld:"FORMCONTAINER",grid:0};n[16]={id:16,fld:"",grid:0};n[17]={id:17,fld:"TOOLBARCELL",grid:0};n[18]={id:18,fld:"",grid:0};n[19]={id:19,fld:"",grid:0};n[20]={id:20,fld:"",grid:0};n[21]={id:21,fld:"BTN_FIRST",grid:0,evt:"e15022_client",std:"FIRST"};n[22]={id:22,fld:"",grid:0};n[23]={id:23,fld:"BTN_PREVIOUS",grid:0,evt:"e16022_client",std:"PREVIOUS"};n[24]={id:24,fld:"",grid:0};n[25]={id:25,fld:"BTN_NEXT",grid:0,evt:"e17022_client",std:"NEXT"};n[26]={id:26,fld:"",grid:0};n[27]={id:27,fld:"BTN_LAST",grid:0,evt:"e18022_client",std:"LAST"};n[28]={id:28,fld:"",grid:0};n[29]={id:29,fld:"BTN_SELECT",grid:0,evt:"e19022_client",std:"SELECT"};n[30]={id:30,fld:"",grid:0};n[31]={id:31,fld:"",grid:0};n[32]={id:32,fld:"",grid:0};n[33]={id:33,fld:"",grid:0};n[34]={id:34,lvl:0,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:1,grid:0,gxgrid:null,fnc:this.Valid_Attractionid,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"ATTRACTIONID",fmt:0,gxz:"Z7AttractionId",gxold:"O7AttractionId",gxvar:"A7AttractionId",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A7AttractionId=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z7AttractionId=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("ATTRACTIONID",gx.O.A7AttractionId,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A7AttractionId=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("ATTRACTIONID",",")},nac:gx.falseFn};this.declareDomainHdlr(34,function(){});n[35]={id:35,fld:"",grid:0};n[36]={id:36,fld:"",grid:0};n[37]={id:37,fld:"",grid:0};n[38]={id:38,fld:"",grid:0};n[39]={id:39,lvl:0,type:"char",len:50,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:this.Valid_Attractionname,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"ATTRACTIONNAME",fmt:0,gxz:"Z8AttractionName",gxold:"O8AttractionName",gxvar:"A8AttractionName",ucs:[],op:[],ip:[34,39],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A8AttractionName=n)},v2z:function(n){n!==undefined&&(gx.O.Z8AttractionName=n)},v2c:function(){gx.fn.setControlValue("ATTRACTIONNAME",gx.O.A8AttractionName,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A8AttractionName=this.val())},val:function(){return gx.fn.getControlValue("ATTRACTIONNAME")},nac:gx.falseFn};this.declareDomainHdlr(39,function(){});n[40]={id:40,fld:"",grid:0};n[41]={id:41,fld:"",grid:0};n[42]={id:42,fld:"",grid:0};n[43]={id:43,fld:"",grid:0};n[44]={id:44,lvl:0,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:0,grid:0,gxgrid:null,fnc:this.Valid_Countryid,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"COUNTRYID",fmt:0,gxz:"Z9CountryId",gxold:"O9CountryId",gxvar:"A9CountryId",ucs:[],op:[49],ip:[49,44],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A9CountryId=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z9CountryId=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("COUNTRYID",gx.O.A9CountryId,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A9CountryId=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("COUNTRYID",",")},nac:function(){return gx.text.compare(this.Gx_mode,"INS")==0&&!(0==this.AV11Insert_CountryId)}};this.declareDomainHdlr(44,function(){});n[45]={id:45,fld:"",grid:0};n[46]={id:46,fld:"",grid:0};n[47]={id:47,fld:"",grid:0};n[48]={id:48,fld:"",grid:0};n[49]={id:49,lvl:0,type:"char",len:50,dec:0,sign:!1,ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"COUNTRYNAME",fmt:0,gxz:"Z10CountryName",gxold:"O10CountryName",gxvar:"A10CountryName",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A10CountryName=n)},v2z:function(n){n!==undefined&&(gx.O.Z10CountryName=n)},v2c:function(){gx.fn.setControlValue("COUNTRYNAME",gx.O.A10CountryName,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A10CountryName=this.val())},val:function(){return gx.fn.getControlValue("COUNTRYNAME")},nac:gx.falseFn};this.declareDomainHdlr(49,function(){});n[50]={id:50,fld:"",grid:0};n[51]={id:51,fld:"",grid:0};n[52]={id:52,fld:"",grid:0};n[53]={id:53,fld:"",grid:0};n[54]={id:54,lvl:0,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:0,grid:0,gxgrid:null,fnc:this.Valid_Categoryid,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"CATEGORYID",fmt:0,gxz:"Z12CategoryId",gxold:"O12CategoryId",gxvar:"A12CategoryId",ucs:[],op:[59],ip:[59,54],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A12CategoryId=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z12CategoryId=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("CATEGORYID",gx.O.A12CategoryId,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A12CategoryId=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("CATEGORYID",",")},nac:function(){return gx.text.compare(this.Gx_mode,"INS")==0&&!(0==this.AV12Insert_CategoryId)}};this.declareDomainHdlr(54,function(){});n[55]={id:55,fld:"",grid:0};n[56]={id:56,fld:"",grid:0};n[57]={id:57,fld:"",grid:0};n[58]={id:58,fld:"",grid:0};n[59]={id:59,lvl:0,type:"char",len:50,dec:0,sign:!1,ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"CATEGORYNAME",fmt:0,gxz:"Z13CategoryName",gxold:"O13CategoryName",gxvar:"A13CategoryName",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A13CategoryName=n)},v2z:function(n){n!==undefined&&(gx.O.Z13CategoryName=n)},v2c:function(){gx.fn.setControlValue("CATEGORYNAME",gx.O.A13CategoryName,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A13CategoryName=this.val())},val:function(){return gx.fn.getControlValue("CATEGORYNAME")},nac:gx.falseFn};this.declareDomainHdlr(59,function(){});n[60]={id:60,fld:"",grid:0};n[61]={id:61,fld:"",grid:0};n[62]={id:62,fld:"",grid:0};n[63]={id:63,fld:"",grid:0};n[64]={id:64,lvl:0,type:"bits",len:1024,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"ATTRACTIONFOTO",fmt:0,gxz:"Z14AttractionFoto",gxold:"O14AttractionFoto",gxvar:"A14AttractionFoto",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A14AttractionFoto=n)},v2z:function(n){n!==undefined&&(gx.O.Z14AttractionFoto=n)},v2c:function(){gx.fn.setMultimediaValue("ATTRACTIONFOTO",gx.O.A14AttractionFoto,gx.O.A40000AttractionFoto_GXI)},c2v:function(){gx.O.A40000AttractionFoto_GXI=this.val_GXI();this.val()!==undefined&&(gx.O.A14AttractionFoto=this.val())},val:function(){return gx.fn.getBlobValue("ATTRACTIONFOTO")},val_GXI:function(){return gx.fn.getControlValue("ATTRACTIONFOTO_GXI")},gxvar_GXI:"A40000AttractionFoto_GXI",nac:gx.falseFn};n[65]={id:65,fld:"",grid:0};n[66]={id:66,fld:"",grid:0};n[67]={id:67,fld:"",grid:0};n[68]={id:68,fld:"",grid:0};n[69]={id:69,lvl:0,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:0,grid:0,gxgrid:null,fnc:this.Valid_Cityid,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"CITYID",fmt:0,gxz:"Z15CityId",gxold:"O15CityId",gxvar:"A15CityId",ucs:[],op:[74],ip:[74,69,44],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A15CityId=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z15CityId=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("CITYID",gx.O.A15CityId,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A15CityId=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("CITYID",",")},nac:function(){return gx.text.compare(this.Gx_mode,"INS")==0&&!(0==this.AV13Insert_CityId)}};this.declareDomainHdlr(69,function(){});n[70]={id:70,fld:"",grid:0};n[71]={id:71,fld:"",grid:0};n[72]={id:72,fld:"",grid:0};n[73]={id:73,fld:"",grid:0};n[74]={id:74,lvl:0,type:"char",len:50,dec:0,sign:!1,ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"CITYNAME",fmt:0,gxz:"Z16CityName",gxold:"O16CityName",gxvar:"A16CityName",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A16CityName=n)},v2z:function(n){n!==undefined&&(gx.O.Z16CityName=n)},v2c:function(){gx.fn.setControlValue("CITYNAME",gx.O.A16CityName,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A16CityName=this.val())},val:function(){return gx.fn.getControlValue("CITYNAME")},nac:gx.falseFn};this.declareDomainHdlr(74,function(){});n[75]={id:75,fld:"",grid:0};n[76]={id:76,fld:"",grid:0};n[77]={id:77,fld:"",grid:0};n[78]={id:78,fld:"",grid:0};n[79]={id:79,fld:"BTN_ENTER",grid:0,evt:"e13022_client",std:"ENTER"};n[80]={id:80,fld:"",grid:0};n[81]={id:81,fld:"BTN_CANCEL",grid:0,evt:"e14022_client"};n[82]={id:82,fld:"",grid:0};n[83]={id:83,fld:"BTN_DELETE",grid:0,evt:"e20022_client",std:"DELETE"};n[84]={id:84,fld:"PROMPT_9",grid:2};n[85]={id:85,fld:"PROMPT_12",grid:2};n[86]={id:86,fld:"PROMPT_15",grid:2};this.A7AttractionId=0;this.Z7AttractionId=0;this.O7AttractionId=0;this.A8AttractionName="";this.Z8AttractionName="";this.O8AttractionName="";this.A9CountryId=0;this.Z9CountryId=0;this.O9CountryId=0;this.A10CountryName="";this.Z10CountryName="";this.O10CountryName="";this.A12CategoryId=0;this.Z12CategoryId=0;this.O12CategoryId=0;this.A13CategoryName="";this.Z13CategoryName="";this.O13CategoryName="";this.A40000AttractionFoto_GXI="";this.A14AttractionFoto="";this.Z14AttractionFoto="";this.O14AttractionFoto="";this.A15CityId=0;this.Z15CityId=0;this.O15CityId=0;this.A16CityName="";this.Z16CityName="";this.O16CityName="";this.A40000AttractionFoto_GXI="";this.AV16Pgmname="";this.AV9TrnContext={CallerObject:"",CallerOnDelete:!1,CallerURL:"",TransactionName:"",Attributes:[]};this.AV11Insert_CountryId=0;this.AV12Insert_CategoryId=0;this.AV13Insert_CityId=0;this.AV17GXV1=0;this.AV14TrnContextAtt={AttributeName:"",AttributeValue:""};this.AV7AttractionId=0;this.AV10WebSession={};this.A7AttractionId=0;this.A9CountryId=0;this.A12CategoryId=0;this.A15CityId=0;this.A8AttractionName="";this.A10CountryName="";this.A13CategoryName="";this.A14AttractionFoto="";this.A16CityName="";this.Gx_mode="";this.Events={e12022_client:["AFTER TRN",!0],e13022_client:["ENTER",!0],e14022_client:["CANCEL",!0]};this.EvtParms.ENTER=[[{postForm:!0},{av:"Gx_mode",fld:"vMODE",pic:"@!",hsh:!0},{av:"AV7AttractionId",fld:"vATTRACTIONID",pic:"ZZZ9",hsh:!0}],[]];this.EvtParms.REFRESH=[[{av:"Gx_mode",fld:"vMODE",pic:"@!",hsh:!0},{av:"AV9TrnContext",fld:"vTRNCONTEXT",hsh:!0},{av:"AV7AttractionId",fld:"vATTRACTIONID",pic:"ZZZ9",hsh:!0},{av:"A7AttractionId",fld:"ATTRACTIONID",pic:"ZZZ9"}],[]];this.EvtParms["AFTER TRN"]=[[{av:"Gx_mode",fld:"vMODE",pic:"@!",hsh:!0},{av:"AV9TrnContext",fld:"vTRNCONTEXT",hsh:!0}],[]];this.EvtParms.VALID_ATTRACTIONID=[[],[]];this.EvtParms.VALID_ATTRACTIONNAME=[[{av:"A8AttractionName",fld:"ATTRACTIONNAME"},{av:"A7AttractionId",fld:"ATTRACTIONID",pic:"ZZZ9"}],[]];this.EvtParms.VALID_COUNTRYID=[[{av:"A9CountryId",fld:"COUNTRYID",pic:"ZZZ9"},{av:"A10CountryName",fld:"COUNTRYNAME"}],[{av:"A10CountryName",fld:"COUNTRYNAME"}]];this.EvtParms.VALID_CATEGORYID=[[{av:"A12CategoryId",fld:"CATEGORYID",pic:"ZZZ9"},{av:"A13CategoryName",fld:"CATEGORYNAME"}],[{av:"A13CategoryName",fld:"CATEGORYNAME"}]];this.EvtParms.VALID_CITYID=[[{av:"A9CountryId",fld:"COUNTRYID",pic:"ZZZ9"},{av:"A15CityId",fld:"CITYID",pic:"ZZZ9"},{av:"A16CityName",fld:"CITYNAME"}],[{av:"A16CityName",fld:"CITYNAME"}]];this.setPrompt("PROMPT_9",[44]);this.setPrompt("PROMPT_12",[54]);this.setPrompt("PROMPT_15",[69]);this.EnterCtrl=["BTN_ENTER"];this.setVCMap("AV7AttractionId","vATTRACTIONID",0,"int",4,0);this.setVCMap("AV11Insert_CountryId","vINSERT_COUNTRYID",0,"int",4,0);this.setVCMap("AV12Insert_CategoryId","vINSERT_CATEGORYID",0,"int",4,0);this.setVCMap("AV13Insert_CityId","vINSERT_CITYID",0,"int",4,0);this.setVCMap("A40000AttractionFoto_GXI","ATTRACTIONFOTO_GXI",0,"svchar",2048,0);this.setVCMap("AV16Pgmname","vPGMNAME",0,"char",129,0);this.setVCMap("Gx_mode","vMODE",0,"char",3,0);this.setVCMap("AV9TrnContext","vTRNCONTEXT",0,"GeneralUITransactionContext",0,0);this.Initialize()});gx.wi(function(){gx.createParentObj(this.attraction)})