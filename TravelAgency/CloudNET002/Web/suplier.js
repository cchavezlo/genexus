gx.evt.autoSkip=!1;gx.define("suplier",!1,function(){var n,t;this.ServerClass="suplier";this.PackageName="GeneXus.Programs";this.ServerFullClass="suplier.aspx";this.setObjectType("trn");this.anyGridBaseTable=!0;this.hasEnterEvent=!0;this.skipOnEnter=!1;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.DSO="TravelAgency";this.SetStandaloneVars=function(){this.A40000AttractionFoto_GXI=gx.fn.getControlValue("ATTRACTIONFOTO_GXI")};this.Valid_Suplierid=function(){return this.validSrvEvt("Valid_Suplierid",0).then(function(n){return n}.closure(this))};this.Valid_Attractionid=function(){var t=gx.fn.currentGridRowImpl(53),n;return gx.fn.currentGridRowImpl(53)===0?!0:(n=gx.util.balloon.getNew("ATTRACTIONID",gx.fn.currentGridRowImpl(53)),gx.fn.gridDuplicateKey(54))?(n.setError(gx.text.format(gx.getMessage("GXM_1004"),"Attraction","","","","","","","","")),this.AnyError=gx.num.trunc(1,0),n.show()):this.validSrvEvt("Valid_Attractionid",53).then(function(n){try{var t;t=this.Gx_mode;this.Gx_mode=gx.fn.getGridRowMode(14,53);this.standaloneModal0914();this.standaloneNotModal0914()}finally{this.Gx_mode=t}return n}.closure(this))};this.Valid_Suplierattractiondate=function(){var n=gx.fn.currentGridRowImpl(53);return this.validCliEvt("Valid_Suplierattractiondate",53,function(){var n,t;try{if(gx.fn.currentGridRowImpl(53)===0)return!0;if(n=gx.util.balloon.getNew("SUPLIERATTRACTIONDATE",gx.fn.currentGridRowImpl(53)),this.AnyError=0,t=this.Gx_mode,this.Gx_mode=gx.fn.getGridRowMode(14,53),!(new gx.date.gxdate("").compare(this.A43SuplierAttractionDate)==0||new gx.date.gxdate(this.A43SuplierAttractionDate).compare(gx.date.ymdtod(1753,1,1))>=0))try{n.setError("Field Suplier Attraction Date is out of range");this.AnyError=gx.num.trunc(1,0)}catch(i){}}catch(i){}try{return(this.Gx_mode=t,n==null)?!0:n.show()}catch(i){}return!0})};this.standaloneModal0914=function(){try{gx.text.compare(this.Gx_mode,"INS")!=0?gx.fn.setCtrlProperty("ATTRACTIONID","Enabled",0):gx.fn.setCtrlProperty("ATTRACTIONID","Enabled",1)}catch(n){}};this.standaloneNotModal0914=function(){};this.e110913_client=function(){return this.executeServerEvent("ENTER",!0,null,!1,!1)};this.e120913_client=function(){return this.executeServerEvent("CANCEL",!0,null,!1,!1)};this.GXValidFnc=[];n=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,9,10,11,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49,50,51,52,54,55,56,57,58,59,60,61,62,63,64,65,66,67];this.GXLastCtrlId=67;this.Gridsuplier_attractionContainer=new gx.grid.grid(this,14,"Attraction",53,"Gridsuplier_attraction","Gridsuplier_attraction","Gridsuplier_attractionContainer",this.CmpContext,this.IsMasterPage,"suplier",[7],!1,1,!1,!0,5,!1,!1,!1,"",0,"px",0,"px","New row",!0,!1,!1,null,null,!1,"",!1,[1,1,1,1],!1,0,!0,!1);t=this.Gridsuplier_attractionContainer;t.addSingleLineEdit(7,54,"ATTRACTIONID","Attraction Id","","AttractionId","int",0,"px",4,4,"end",null,[],7,"AttractionId",!0,0,!1,!1,"Attribute",0,"");t.addBitmap("prompt_7","PROMPT_7",67,0,"",0,"",null,"","","gx-prompt Image","");t.addSingleLineEdit(8,55,"ATTRACTIONNAME","Attraction Name","","AttractionName","char",0,"px",50,50,"start",null,[],8,"AttractionName",!0,0,!1,!1,"Attribute",0,"");t.addBitmap(14,"ATTRACTIONFOTO",56,0,"px",17,"px",null,"","Attraction Foto","ImageAttribute","");t.addSingleLineEdit(43,57,"SUPLIERATTRACTIONDATE","Attraction Date","","SuplierAttractionDate","date",0,"px",8,8,"end",null,[],43,"SuplierAttractionDate",!0,0,!1,!1,"Attribute",0,"");this.Gridsuplier_attractionContainer.emptyText="";this.setGrid(t);n[2]={id:2,fld:"",grid:0};n[3]={id:3,fld:"MAINTABLE",grid:0};n[4]={id:4,fld:"",grid:0};n[5]={id:5,fld:"",grid:0};n[6]={id:6,fld:"TITLECONTAINER",grid:0};n[7]={id:7,fld:"",grid:0};n[8]={id:8,fld:"",grid:0};n[9]={id:9,fld:"TITLE",format:0,grid:0,ctrltype:"textblock"};n[10]={id:10,fld:"",grid:0};n[11]={id:11,fld:"",grid:0};n[13]={id:13,fld:"",grid:0};n[14]={id:14,fld:"",grid:0};n[15]={id:15,fld:"FORMCONTAINER",grid:0};n[16]={id:16,fld:"",grid:0};n[17]={id:17,fld:"TOOLBARCELL",grid:0};n[18]={id:18,fld:"",grid:0};n[19]={id:19,fld:"",grid:0};n[20]={id:20,fld:"",grid:0};n[21]={id:21,fld:"BTN_FIRST",grid:0,evt:"e130913_client",std:"FIRST"};n[22]={id:22,fld:"",grid:0};n[23]={id:23,fld:"BTN_PREVIOUS",grid:0,evt:"e140913_client",std:"PREVIOUS"};n[24]={id:24,fld:"",grid:0};n[25]={id:25,fld:"BTN_NEXT",grid:0,evt:"e150913_client",std:"NEXT"};n[26]={id:26,fld:"",grid:0};n[27]={id:27,fld:"BTN_LAST",grid:0,evt:"e160913_client",std:"LAST"};n[28]={id:28,fld:"",grid:0};n[29]={id:29,fld:"BTN_SELECT",grid:0,evt:"e170913_client",std:"SELECT"};n[30]={id:30,fld:"",grid:0};n[31]={id:31,fld:"",grid:0};n[32]={id:32,fld:"",grid:0};n[33]={id:33,fld:"",grid:0};n[34]={id:34,lvl:0,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:0,grid:0,gxgrid:null,fnc:this.Valid_Suplierid,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[this.Gridsuplier_attractionContainer],fld:"SUPLIERID",fmt:0,gxz:"Z37SuplierId",gxold:"O37SuplierId",gxvar:"A37SuplierId",ucs:[],op:[44,39],ip:[44,39,34],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A37SuplierId=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z37SuplierId=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("SUPLIERID",gx.O.A37SuplierId,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A37SuplierId=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("SUPLIERID",",")},nac:gx.falseFn};this.declareDomainHdlr(34,function(){});n[35]={id:35,fld:"",grid:0};n[36]={id:36,fld:"",grid:0};n[37]={id:37,fld:"",grid:0};n[38]={id:38,fld:"",grid:0};n[39]={id:39,lvl:0,type:"char",len:50,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"SUPLIERNAME",fmt:0,gxz:"Z38SuplierName",gxold:"O38SuplierName",gxvar:"A38SuplierName",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A38SuplierName=n)},v2z:function(n){n!==undefined&&(gx.O.Z38SuplierName=n)},v2c:function(){gx.fn.setControlValue("SUPLIERNAME",gx.O.A38SuplierName,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A38SuplierName=this.val())},val:function(){return gx.fn.getControlValue("SUPLIERNAME")},nac:gx.falseFn};this.declareDomainHdlr(39,function(){});n[40]={id:40,fld:"",grid:0};n[41]={id:41,fld:"",grid:0};n[42]={id:42,fld:"",grid:0};n[43]={id:43,fld:"",grid:0};n[44]={id:44,lvl:0,type:"svchar",len:1024,dec:0,sign:!1,ro:0,multiline:!0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"SUPLIERADDRESS",fmt:0,gxz:"Z39SuplierAddress",gxold:"O39SuplierAddress",gxvar:"A39SuplierAddress",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A39SuplierAddress=n)},v2z:function(n){n!==undefined&&(gx.O.Z39SuplierAddress=n)},v2c:function(){gx.fn.setControlValue("SUPLIERADDRESS",gx.O.A39SuplierAddress,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A39SuplierAddress=this.val())},val:function(){return gx.fn.getControlValue("SUPLIERADDRESS")},nac:gx.falseFn};this.declareDomainHdlr(44,function(){gx.fn.setCtrlProperty("SUPLIERADDRESS","Link",gx.fn.getCtrlProperty("SUPLIERADDRESS","Enabled")?"":"http://maps.google.com/maps?q="+encodeURIComponent(this.A39SuplierAddress))});n[45]={id:45,fld:"",grid:0};n[46]={id:46,fld:"",grid:0};n[47]={id:47,fld:"ATTRACTIONTABLE",grid:0};n[48]={id:48,fld:"",grid:0};n[49]={id:49,fld:"",grid:0};n[50]={id:50,fld:"TITLEATTRACTION",format:0,grid:0,ctrltype:"textblock"};n[51]={id:51,fld:"",grid:0};n[52]={id:52,fld:"",grid:0};n[54]={id:54,lvl:14,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:0,isacc:1,grid:53,gxgrid:this.Gridsuplier_attractionContainer,fnc:this.Valid_Attractionid,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"ATTRACTIONID",fmt:0,gxz:"Z7AttractionId",gxold:"O7AttractionId",gxvar:"A7AttractionId",ucs:[],op:[56,55],ip:[56,55,54],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A7AttractionId=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z7AttractionId=gx.num.intval(n))},v2c:function(n){gx.fn.setGridControlValue("ATTRACTIONID",n||gx.fn.currentGridRowImpl(53),gx.O.A7AttractionId,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A7AttractionId=gx.num.intval(this.val(n)))},val:function(n){return gx.fn.getGridIntegerValue("ATTRACTIONID",n||gx.fn.currentGridRowImpl(53),",")},nac:gx.falseFn};n[55]={id:55,lvl:14,type:"char",len:50,dec:0,sign:!1,ro:1,isacc:1,grid:53,gxgrid:this.Gridsuplier_attractionContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"ATTRACTIONNAME",fmt:0,gxz:"Z8AttractionName",gxold:"O8AttractionName",gxvar:"A8AttractionName",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.A8AttractionName=n)},v2z:function(n){n!==undefined&&(gx.O.Z8AttractionName=n)},v2c:function(n){gx.fn.setGridControlValue("ATTRACTIONNAME",n||gx.fn.currentGridRowImpl(53),gx.O.A8AttractionName,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A8AttractionName=this.val(n))},val:function(n){return gx.fn.getGridControlValue("ATTRACTIONNAME",n||gx.fn.currentGridRowImpl(53))},nac:gx.falseFn};n[56]={id:56,lvl:14,type:"bits",len:1024,dec:0,sign:!1,ro:1,isacc:1,grid:53,gxgrid:this.Gridsuplier_attractionContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"ATTRACTIONFOTO",fmt:0,gxz:"Z14AttractionFoto",gxold:"O14AttractionFoto",gxvar:"A14AttractionFoto",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A14AttractionFoto=n)},v2z:function(n){n!==undefined&&(gx.O.Z14AttractionFoto=n)},v2c:function(n){gx.fn.setGridMultimediaValue("ATTRACTIONFOTO",n||gx.fn.currentGridRowImpl(53),gx.O.A14AttractionFoto,gx.O.A40000AttractionFoto_GXI)},c2v:function(n){gx.O.A40000AttractionFoto_GXI=this.val_GXI();this.val(n)!==undefined&&(gx.O.A14AttractionFoto=this.val(n))},val:function(n){return gx.fn.getGridControlValue("ATTRACTIONFOTO",n||gx.fn.currentGridRowImpl(53))},val_GXI:function(n){return gx.fn.getGridControlValue("ATTRACTIONFOTO_GXI",n||gx.fn.currentGridRowImpl(53))},gxvar_GXI:"A40000AttractionFoto_GXI",nac:gx.falseFn};n[57]={id:57,lvl:14,type:"date",len:8,dec:0,sign:!1,ro:0,isacc:1,grid:53,gxgrid:this.Gridsuplier_attractionContainer,fnc:this.Valid_Suplierattractiondate,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"SUPLIERATTRACTIONDATE",fmt:0,gxz:"Z43SuplierAttractionDate",gxold:"O43SuplierAttractionDate",gxvar:"A43SuplierAttractionDate",dp:{f:0,st:!1,wn:!1,mf:!1,pic:"99/99/99",dec:0},ucs:[],op:[57],ip:[57],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A43SuplierAttractionDate=gx.fn.toDatetimeValue(n))},v2z:function(n){n!==undefined&&(gx.O.Z43SuplierAttractionDate=gx.fn.toDatetimeValue(n))},v2c:function(n){gx.fn.setGridControlValue("SUPLIERATTRACTIONDATE",n||gx.fn.currentGridRowImpl(53),gx.O.A43SuplierAttractionDate,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A43SuplierAttractionDate=gx.fn.toDatetimeValue(this.val(n)))},val:function(n){return gx.fn.getGridDateTimeValue("SUPLIERATTRACTIONDATE",n||gx.fn.currentGridRowImpl(53))},nac:gx.falseFn};n[58]={id:58,fld:"",grid:0};n[59]={id:59,fld:"",grid:0};n[60]={id:60,fld:"",grid:0};n[61]={id:61,fld:"",grid:0};n[62]={id:62,fld:"BTN_ENTER",grid:0,evt:"e110913_client",std:"ENTER"};n[63]={id:63,fld:"",grid:0};n[64]={id:64,fld:"BTN_CANCEL",grid:0,evt:"e120913_client"};n[65]={id:65,fld:"",grid:0};n[66]={id:66,fld:"BTN_DELETE",grid:0,evt:"e180913_client",std:"DELETE"};n[67]={id:67,fld:"PROMPT_7",grid:14};this.A37SuplierId=0;this.Z37SuplierId=0;this.O37SuplierId=0;this.A38SuplierName="";this.Z38SuplierName="";this.O38SuplierName="";this.A39SuplierAddress="";this.Z39SuplierAddress="";this.O39SuplierAddress="";this.Z7AttractionId=0;this.O7AttractionId=0;this.Z8AttractionName="";this.O8AttractionName="";this.Z14AttractionFoto="";this.O14AttractionFoto="";this.Z43SuplierAttractionDate=gx.date.nullDate();this.O43SuplierAttractionDate=gx.date.nullDate();this.A40000AttractionFoto_GXI="";this.A7AttractionId=0;this.A8AttractionName="";this.A14AttractionFoto="";this.A43SuplierAttractionDate=gx.date.nullDate();this.A37SuplierId=0;this.A38SuplierName="";this.A39SuplierAddress="";this.Events={e110913_client:["ENTER",!0],e120913_client:["CANCEL",!0]};this.EvtParms.ENTER=[[{postForm:!0}],[]];this.EvtParms.REFRESH=[[],[]];this.EvtParms.VALID_SUPLIERID=[[{av:"A37SuplierId",fld:"SUPLIERID",pic:"ZZZ9"},{av:"Gx_mode",fld:"vMODE",pic:"@!"}],[{av:"A38SuplierName",fld:"SUPLIERNAME"},{av:"A39SuplierAddress",fld:"SUPLIERADDRESS"},{av:"Gx_mode",fld:"vMODE",pic:"@!"},{av:"Z37SuplierId"},{av:"Z38SuplierName"},{av:"Z39SuplierAddress"},{ctrl:"BTN_DELETE",prop:"Enabled"},{ctrl:"BTN_ENTER",prop:"Enabled"}]];this.EvtParms.VALID_ATTRACTIONID=[[{av:"A7AttractionId",fld:"ATTRACTIONID",pic:"ZZZ9"},{av:"A8AttractionName",fld:"ATTRACTIONNAME"},{av:"A14AttractionFoto",fld:"ATTRACTIONFOTO"},{av:"A40000AttractionFoto_GXI",fld:"ATTRACTIONFOTO_GXI"}],[{av:"A8AttractionName",fld:"ATTRACTIONNAME"},{av:"A14AttractionFoto",fld:"ATTRACTIONFOTO"},{av:"A40000AttractionFoto_GXI",fld:"ATTRACTIONFOTO_GXI"}]];this.EvtParms.VALID_SUPLIERATTRACTIONDATE=[[{av:"A43SuplierAttractionDate",fld:"SUPLIERATTRACTIONDATE"}],[{av:"A43SuplierAttractionDate",fld:"SUPLIERATTRACTIONDATE"}]];this.setPrompt("PROMPT_7",[54]);this.EnterCtrl=["BTN_ENTER"];this.setVCMap("A40000AttractionFoto_GXI","ATTRACTIONFOTO_GXI",53,"svchar",2048,0);t.addPostingVar({rfrVar:"Gx_mode"});this.Initialize()});gx.wi(function(){gx.createParentObj(this.suplier)})