gx.evt.autoSkip=!1;gx.define("customer",!1,function(){this.ServerClass="customer";this.PackageName="GeneXus.Programs";this.ServerFullClass="customer.aspx";this.setObjectType("trn");this.hasEnterEvent=!0;this.skipOnEnter=!1;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.DSO="TravelAgency";this.SetStandaloneVars=function(){this.Gx_date=gx.fn.getDateValue("vTODAY");this.Gx_BScreen=gx.fn.getIntegerValue("vGXBSCREEN",",")};this.Valid_Customerid=function(){return this.validSrvEvt("Valid_Customerid",0).then(function(n){return n}.closure(this))};this.Valid_Customername=function(){return this.validCliEvt("Valid_Customername",0,function(){try{var n=gx.util.balloon.getNew("CUSTOMERNAME");if(this.AnyError=0,gx.text.compare("",this.A2CustomerName)==0)try{n.setError("Complete el nombre del cliente");this.AnyError=gx.num.trunc(1,0)}catch(t){}}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.Valid_Customerphone=function(){return this.validCliEvt("Valid_Customerphone",0,function(){try{var n=gx.util.balloon.getNew("CUSTOMERPHONE");if(this.AnyError=0,gx.text.compare("",this.A5CustomerPhone)==0)try{n.setMessage("Complete el telefono del cliente")}catch(t){}}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.e11011_client=function(){return this.executeServerEvent("ENTER",!0,null,!1,!1)};this.e12011_client=function(){return this.executeServerEvent("CANCEL",!0,null,!1,!1)};this.GXValidFnc=[];var n=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,9,10,11,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49,50,51,52,53,54,55,56,57,58,59,60,61,62,63,64,65,66,67,68];this.GXLastCtrlId=68;n[2]={id:2,fld:"",grid:0};n[3]={id:3,fld:"MAINTABLE",grid:0};n[4]={id:4,fld:"",grid:0};n[5]={id:5,fld:"",grid:0};n[6]={id:6,fld:"TITLECONTAINER",grid:0};n[7]={id:7,fld:"",grid:0};n[8]={id:8,fld:"",grid:0};n[9]={id:9,fld:"TITLE",format:0,grid:0,ctrltype:"textblock"};n[10]={id:10,fld:"",grid:0};n[11]={id:11,fld:"",grid:0};n[13]={id:13,fld:"",grid:0};n[14]={id:14,fld:"",grid:0};n[15]={id:15,fld:"FORMCONTAINER",grid:0};n[16]={id:16,fld:"",grid:0};n[17]={id:17,fld:"TOOLBARCELL",grid:0};n[18]={id:18,fld:"",grid:0};n[19]={id:19,fld:"",grid:0};n[20]={id:20,fld:"",grid:0};n[21]={id:21,fld:"BTN_FIRST",grid:0,evt:"e13011_client",std:"FIRST"};n[22]={id:22,fld:"",grid:0};n[23]={id:23,fld:"BTN_PREVIOUS",grid:0,evt:"e14011_client",std:"PREVIOUS"};n[24]={id:24,fld:"",grid:0};n[25]={id:25,fld:"BTN_NEXT",grid:0,evt:"e15011_client",std:"NEXT"};n[26]={id:26,fld:"",grid:0};n[27]={id:27,fld:"BTN_LAST",grid:0,evt:"e16011_client",std:"LAST"};n[28]={id:28,fld:"",grid:0};n[29]={id:29,fld:"BTN_SELECT",grid:0,evt:"e17011_client",std:"SELECT"};n[30]={id:30,fld:"",grid:0};n[31]={id:31,fld:"",grid:0};n[32]={id:32,fld:"",grid:0};n[33]={id:33,fld:"",grid:0};n[34]={id:34,lvl:0,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:0,grid:0,gxgrid:null,fnc:this.Valid_Customerid,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"CUSTOMERID",fmt:0,gxz:"Z1CustomerId",gxold:"O1CustomerId",gxvar:"A1CustomerId",ucs:[],op:[59,54,49,44,39],ip:[59,54,49,44,39,34],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A1CustomerId=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z1CustomerId=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("CUSTOMERID",gx.O.A1CustomerId,0)},c2v:function(){this.val()!==undefined&&(gx.O.A1CustomerId=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("CUSTOMERID",",")},nac:gx.falseFn};n[35]={id:35,fld:"",grid:0};n[36]={id:36,fld:"",grid:0};n[37]={id:37,fld:"",grid:0};n[38]={id:38,fld:"",grid:0};n[39]={id:39,lvl:0,type:"char",len:20,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:this.Valid_Customername,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"CUSTOMERNAME",fmt:0,gxz:"Z2CustomerName",gxold:"O2CustomerName",gxvar:"A2CustomerName",ucs:[],op:[39],ip:[39],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A2CustomerName=n)},v2z:function(n){n!==undefined&&(gx.O.Z2CustomerName=n)},v2c:function(){gx.fn.setControlValue("CUSTOMERNAME",gx.O.A2CustomerName,0)},c2v:function(){this.val()!==undefined&&(gx.O.A2CustomerName=this.val())},val:function(){return gx.fn.getControlValue("CUSTOMERNAME")},nac:gx.falseFn};n[40]={id:40,fld:"",grid:0};n[41]={id:41,fld:"",grid:0};n[42]={id:42,fld:"",grid:0};n[43]={id:43,fld:"",grid:0};n[44]={id:44,lvl:0,type:"char",len:20,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"CUSTOMERLASTNAME",fmt:0,gxz:"Z3CustomerLastName",gxold:"O3CustomerLastName",gxvar:"A3CustomerLastName",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A3CustomerLastName=n)},v2z:function(n){n!==undefined&&(gx.O.Z3CustomerLastName=n)},v2c:function(){gx.fn.setControlValue("CUSTOMERLASTNAME",gx.O.A3CustomerLastName,0)},c2v:function(){this.val()!==undefined&&(gx.O.A3CustomerLastName=this.val())},val:function(){return gx.fn.getControlValue("CUSTOMERLASTNAME")},nac:gx.falseFn};n[45]={id:45,fld:"",grid:0};n[46]={id:46,fld:"",grid:0};n[47]={id:47,fld:"",grid:0};n[48]={id:48,fld:"",grid:0};n[49]={id:49,lvl:0,type:"svchar",len:1024,dec:0,sign:!1,ro:0,multiline:!0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"CUSTOMERADDRESS",fmt:0,gxz:"Z4CustomerAddress",gxold:"O4CustomerAddress",gxvar:"A4CustomerAddress",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A4CustomerAddress=n)},v2z:function(n){n!==undefined&&(gx.O.Z4CustomerAddress=n)},v2c:function(){gx.fn.setControlValue("CUSTOMERADDRESS",gx.O.A4CustomerAddress,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A4CustomerAddress=this.val())},val:function(){return gx.fn.getControlValue("CUSTOMERADDRESS")},nac:gx.falseFn};this.declareDomainHdlr(49,function(){gx.fn.setCtrlProperty("CUSTOMERADDRESS","Link",gx.fn.getCtrlProperty("CUSTOMERADDRESS","Enabled")?"":"http://maps.google.com/maps?q="+encodeURIComponent(this.A4CustomerAddress))});n[50]={id:50,fld:"",grid:0};n[51]={id:51,fld:"",grid:0};n[52]={id:52,fld:"",grid:0};n[53]={id:53,fld:"",grid:0};n[54]={id:54,lvl:0,type:"char",len:20,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:this.Valid_Customerphone,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"CUSTOMERPHONE",fmt:0,gxz:"Z5CustomerPhone",gxold:"O5CustomerPhone",gxvar:"A5CustomerPhone",ucs:[],op:[],ip:[54],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A5CustomerPhone=n)},v2z:function(n){n!==undefined&&(gx.O.Z5CustomerPhone=n)},v2c:function(){gx.fn.setControlValue("CUSTOMERPHONE",gx.O.A5CustomerPhone,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A5CustomerPhone=this.val())},val:function(){return gx.fn.getControlValue("CUSTOMERPHONE")},nac:gx.falseFn};this.declareDomainHdlr(54,function(){});n[55]={id:55,fld:"",grid:0};n[56]={id:56,fld:"",grid:0};n[57]={id:57,fld:"",grid:0};n[58]={id:58,fld:"",grid:0};n[59]={id:59,lvl:0,type:"date",len:8,dec:0,sign:!1,ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"CUSTOMERADDEDDATE",fmt:0,gxz:"Z17CustomerAddedDate",gxold:"O17CustomerAddedDate",gxvar:"A17CustomerAddedDate",dp:{f:0,st:!1,wn:!1,mf:!1,pic:"99/99/99",dec:0},ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A17CustomerAddedDate=gx.fn.toDatetimeValue(n))},v2z:function(n){n!==undefined&&(gx.O.Z17CustomerAddedDate=gx.fn.toDatetimeValue(n))},v2c:function(){gx.fn.setControlValue("CUSTOMERADDEDDATE",gx.O.A17CustomerAddedDate,0)},c2v:function(){this.val()!==undefined&&(gx.O.A17CustomerAddedDate=gx.fn.toDatetimeValue(this.val()))},val:function(){return gx.fn.getControlValue("CUSTOMERADDEDDATE")},nac:gx.falseFn};n[60]={id:60,fld:"",grid:0};n[61]={id:61,fld:"",grid:0};n[62]={id:62,fld:"",grid:0};n[63]={id:63,fld:"",grid:0};n[64]={id:64,fld:"BTN_ENTER",grid:0,evt:"e11011_client",std:"ENTER"};n[65]={id:65,fld:"",grid:0};n[66]={id:66,fld:"BTN_CANCEL",grid:0,evt:"e12011_client"};n[67]={id:67,fld:"",grid:0};n[68]={id:68,fld:"BTN_DELETE",grid:0,evt:"e18011_client",std:"DELETE"};this.A1CustomerId=0;this.Z1CustomerId=0;this.O1CustomerId=0;this.A2CustomerName="";this.Z2CustomerName="";this.O2CustomerName="";this.A3CustomerLastName="";this.Z3CustomerLastName="";this.O3CustomerLastName="";this.A4CustomerAddress="";this.Z4CustomerAddress="";this.O4CustomerAddress="";this.A5CustomerPhone="";this.Z5CustomerPhone="";this.O5CustomerPhone="";this.A17CustomerAddedDate=gx.date.nullDate();this.Z17CustomerAddedDate=gx.date.nullDate();this.O17CustomerAddedDate=gx.date.nullDate();this.A1CustomerId=0;this.Gx_BScreen=0;this.Gx_date=gx.date.nullDate();this.A2CustomerName="";this.A3CustomerLastName="";this.A4CustomerAddress="";this.A5CustomerPhone="";this.A17CustomerAddedDate=gx.date.nullDate();this.Events={e11011_client:["ENTER",!0],e12011_client:["CANCEL",!0]};this.EvtParms.ENTER=[[{postForm:!0}],[]];this.EvtParms.REFRESH=[[{av:"A17CustomerAddedDate",fld:"CUSTOMERADDEDDATE"}],[]];this.EvtParms.VALID_CUSTOMERID=[[{av:"A1CustomerId",fld:"CUSTOMERID",pic:"ZZZ9"},{av:"Gx_date",fld:"vTODAY"},{av:"Gx_BScreen",fld:"vGXBSCREEN",pic:"9"},{av:"Gx_mode",fld:"vMODE",pic:"@!"},{av:"A17CustomerAddedDate",fld:"CUSTOMERADDEDDATE"}],[{av:"A2CustomerName",fld:"CUSTOMERNAME"},{av:"A3CustomerLastName",fld:"CUSTOMERLASTNAME"},{av:"A4CustomerAddress",fld:"CUSTOMERADDRESS"},{av:"A5CustomerPhone",fld:"CUSTOMERPHONE"},{av:"A17CustomerAddedDate",fld:"CUSTOMERADDEDDATE"},{av:"Gx_mode",fld:"vMODE",pic:"@!"},{av:"Z1CustomerId"},{av:"Z2CustomerName"},{av:"Z3CustomerLastName"},{av:"Z4CustomerAddress"},{av:"Z5CustomerPhone"},{av:"Z17CustomerAddedDate"},{ctrl:"BTN_DELETE",prop:"Enabled"},{ctrl:"BTN_ENTER",prop:"Enabled"}]];this.EvtParms.VALID_CUSTOMERNAME=[[{av:"A2CustomerName",fld:"CUSTOMERNAME"}],[{av:"A2CustomerName",fld:"CUSTOMERNAME"}]];this.EvtParms.VALID_CUSTOMERPHONE=[[{av:"A5CustomerPhone",fld:"CUSTOMERPHONE"}],[]];this.EnterCtrl=["BTN_ENTER"];this.setVCMap("Gx_date","vTODAY",0,"date",8,0);this.setVCMap("Gx_BScreen","vGXBSCREEN",0,"int",1,0);this.Initialize()});gx.wi(function(){gx.createParentObj(this.customer)})