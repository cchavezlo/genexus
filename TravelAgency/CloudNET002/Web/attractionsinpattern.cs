using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using System.Data;
using GeneXus.Data;
using com.genexus;
using GeneXus.Data.ADO;
using GeneXus.Data.NTier;
using GeneXus.Data.NTier.ADO;
using GeneXus.WebControls;
using GeneXus.Http;
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class attractionsinpattern : GXDataArea
   {
      protected void INITENV( )
      {
         if ( GxWebError != 0 )
         {
            return  ;
         }
      }

      protected void INITTRN( )
      {
         initialize_properties( ) ;
         entryPointCalled = false;
         gxfirstwebparm = GetNextPar( );
         gxfirstwebparm_bkp = gxfirstwebparm;
         gxfirstwebparm = DecryptAjaxCall( gxfirstwebparm);
         toggleJsOutput = isJsOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         if ( StringUtil.StrCmp(gxfirstwebparm, "dyncall") == 0 )
         {
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            dyncall( GetNextPar( )) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_6") == 0 )
         {
            A9CountryId = (short)(Math.Round(NumberUtil.Val( GetPar( "CountryId"), "."), 18, MidpointRounding.ToEven));
            n9CountryId = false;
            AssignAttri("", false, "A9CountryId", StringUtil.LTrimStr( (decimal)(A9CountryId), 4, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_6( A9CountryId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_7") == 0 )
         {
            A9CountryId = (short)(Math.Round(NumberUtil.Val( GetPar( "CountryId"), "."), 18, MidpointRounding.ToEven));
            n9CountryId = false;
            AssignAttri("", false, "A9CountryId", StringUtil.LTrimStr( (decimal)(A9CountryId), 4, 0));
            A15CityId = (short)(Math.Round(NumberUtil.Val( GetPar( "CityId"), "."), 18, MidpointRounding.ToEven));
            n15CityId = false;
            AssignAttri("", false, "A15CityId", StringUtil.LTrimStr( (decimal)(A15CityId), 4, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_7( A9CountryId, A15CityId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_8") == 0 )
         {
            A12CategoryId = (short)(Math.Round(NumberUtil.Val( GetPar( "CategoryId"), "."), 18, MidpointRounding.ToEven));
            n12CategoryId = false;
            AssignAttri("", false, "A12CategoryId", StringUtil.LTrimStr( (decimal)(A12CategoryId), 4, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_8( A12CategoryId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxEvt") == 0 )
         {
            setAjaxEventMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxfirstwebparm = GetNextPar( );
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
         {
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxfirstwebparm = GetNextPar( );
         }
         else
         {
            if ( ! IsValidAjaxCall( false) )
            {
               GxWebError = 1;
               return  ;
            }
            gxfirstwebparm = gxfirstwebparm_bkp;
         }
         if ( toggleJsOutput )
         {
            if ( context.isSpaRequest( ) )
            {
               enableJsOutput();
            }
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
         {
            gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         toggleJsOutput = isJsOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_web_controls( ) ;
         if ( toggleJsOutput )
         {
            if ( context.isSpaRequest( ) )
            {
               enableJsOutput();
            }
         }
         if ( ! context.isSpaRequest( ) )
         {
            if ( context.ExposeMetadata( ) )
            {
               Form.Meta.addItem("generator", "GeneXus .NET 18_0_9-182098", 0) ;
            }
         }
         Form.Meta.addItem("description", "Attraction Sin Pattern", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtAttractionId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("TravelAgency", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public attractionsinpattern( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("TravelAgency", true);
      }

      public attractionsinpattern( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( )
      {
         ExecuteImpl();
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
      }

      public override void webExecute( )
      {
         createObjects();
         initialize();
         INITENV( ) ;
         INITTRN( ) ;
         if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
         {
            MasterPageObj = (GXMasterPage) ClassLoader.GetInstance("general.ui.masterunanimosidebar", "GeneXus.Programs.general.ui.masterunanimosidebar", new Object[] {context});
            MasterPageObj.setDataArea(this,false);
            ValidateSpaRequest();
            MasterPageObj.webExecute();
            if ( ( GxWebError == 0 ) && context.isAjaxRequest( ) )
            {
               enableOutput();
               if ( ! context.isAjaxRequest( ) )
               {
                  context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
               }
               if ( ! context.WillRedirect( ) )
               {
                  AddString( context.getJSONResponse( )) ;
               }
               else
               {
                  if ( context.isAjaxRequest( ) )
                  {
                     disableOutput();
                  }
                  RenderHtmlHeaders( ) ;
                  context.Redirect( context.wjLoc );
                  context.DispatchAjaxCommands();
               }
            }
         }
         this.cleanup();
      }

      protected void fix_multi_value_controls( )
      {
      }

      protected void Draw( )
      {
         if ( context.isAjaxRequest( ) )
         {
            disableOutput();
         }
         if ( ! GxWebStd.gx_redirect( context) )
         {
            disable_std_buttons( ) ;
            enableDisable( ) ;
            set_caption( ) ;
            /* Form start */
            DrawControls( ) ;
            fix_multi_value_controls( ) ;
         }
         /* Execute Exit event if defined. */
      }

      protected void DrawControls( )
      {
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "start", "top", " "+"data-gx-base-lib=\"none\""+" "+"data-abstract-form"+" ", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divMaintable_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTitlecontainer_Internalname, 1, 0, "px", 0, "px", "title-container", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "Attraction Sin Pattern", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "heading-01", 0, "", 1, 1, 0, 0, "HLP_AttractionSinPattern.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         ClassString = "ErrorViewer";
         StyleString = "";
         GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, StyleString, ClassString, "", "false");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divFormcontainer_Internalname, 1, 0, "px", 0, "px", "form-container", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divToolbarcell_Internalname, 1, 0, "px", 0, "px", "col-xs-12 col-sm-9 col-sm-offset-3 form__toolbar-cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group ActionGroup", "start", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "btn-group", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-first";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "", bttBtn_first_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_AttractionSinPattern.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-prev";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "", bttBtn_previous_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_AttractionSinPattern.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-next";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", "", bttBtn_next_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_AttractionSinPattern.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-last";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", "", bttBtn_last_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_AttractionSinPattern.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         ClassString = "Button button-secondary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Select", bttBtn_select_Jsonclick, 4, "Select", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "gx.popup.openPrompt('"+"gx0020.aspx"+"',["+"{Ctrl:gx.dom.el('"+"ATTRACTIONID"+"'), id:'"+"ATTRACTIONID"+"'"+",IOType:'out',isKey:true,isLastKey:true}"+"],"+"null"+","+"'', false"+","+"true"+");"+"return false;", 2, "HLP_AttractionSinPattern.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell-advanced", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtAttractionId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtAttractionId_Internalname, "Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtAttractionId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A7AttractionId), 4, 0, ".", "")), StringUtil.LTrim( ((edtAttractionId_Enabled!=0) ? context.localUtil.Format( (decimal)(A7AttractionId), "ZZZ9") : context.localUtil.Format( (decimal)(A7AttractionId), "ZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,34);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtAttractionId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtAttractionId_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_AttractionSinPattern.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtAttractionName_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtAttractionName_Internalname, "Name", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtAttractionName_Internalname, StringUtil.RTrim( A8AttractionName), StringUtil.RTrim( context.localUtil.Format( A8AttractionName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,39);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtAttractionName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtAttractionName_Enabled, 0, "text", "", 50, "chr", 1, "row", 50, 0, 0, 0, 0, -1, -1, true, "Name", "start", true, "", "HLP_AttractionSinPattern.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtCountryId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCountryId_Internalname, "Country Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCountryId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A9CountryId), 4, 0, ".", "")), StringUtil.LTrim( ((edtCountryId_Enabled!=0) ? context.localUtil.Format( (decimal)(A9CountryId), "ZZZ9") : context.localUtil.Format( (decimal)(A9CountryId), "ZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,44);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCountryId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCountryId_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_AttractionSinPattern.htm");
         /* Static images/pictures */
         ClassString = "gx-prompt Image" + " " + ((StringUtil.StrCmp(imgprompt_9_gximage, "")==0) ? "" : "GX_Image_"+imgprompt_9_gximage+"_Class");
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "prompt.gif", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_9_Internalname, sImgUrl, imgprompt_9_Link, "", "", context.GetTheme( ), imgprompt_9_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_AttractionSinPattern.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtCountryName_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCountryName_Internalname, "Country Name", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtCountryName_Internalname, StringUtil.RTrim( A10CountryName), StringUtil.RTrim( context.localUtil.Format( A10CountryName, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCountryName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCountryName_Enabled, 0, "text", "", 50, "chr", 1, "row", 50, 0, 0, 0, 0, -1, -1, true, "Name", "start", true, "", "HLP_AttractionSinPattern.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtCategoryId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCategoryId_Internalname, "Category Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCategoryId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A12CategoryId), 4, 0, ".", "")), StringUtil.LTrim( ((edtCategoryId_Enabled!=0) ? context.localUtil.Format( (decimal)(A12CategoryId), "ZZZ9") : context.localUtil.Format( (decimal)(A12CategoryId), "ZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,54);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCategoryId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCategoryId_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_AttractionSinPattern.htm");
         /* Static images/pictures */
         ClassString = "gx-prompt Image" + " " + ((StringUtil.StrCmp(imgprompt_12_gximage, "")==0) ? "" : "GX_Image_"+imgprompt_12_gximage+"_Class");
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "prompt.gif", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_12_Internalname, sImgUrl, imgprompt_12_Link, "", "", context.GetTheme( ), imgprompt_12_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_AttractionSinPattern.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtCategoryName_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCategoryName_Internalname, "Category Name", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtCategoryName_Internalname, StringUtil.RTrim( A13CategoryName), StringUtil.RTrim( context.localUtil.Format( A13CategoryName, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCategoryName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCategoryName_Enabled, 0, "text", "", 50, "chr", 1, "row", 50, 0, 0, 0, 0, -1, -1, true, "Name", "start", true, "", "HLP_AttractionSinPattern.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+imgAttractionFoto_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, "", "Foto", "col-sm-3 ImageAttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Static Bitmap Variable */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 64,'',false,'',0)\"";
         ClassString = "ImageAttribute";
         StyleString = "";
         A14AttractionFoto_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( A14AttractionFoto))&&String.IsNullOrEmpty(StringUtil.RTrim( A40000AttractionFoto_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( A14AttractionFoto)));
         sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( A14AttractionFoto)) ? A40000AttractionFoto_GXI : context.PathToRelativeUrl( A14AttractionFoto));
         GxWebStd.gx_bitmap( context, imgAttractionFoto_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, imgAttractionFoto_Enabled, "", "", 0, -1, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,64);\"", "", "", "", 0, A14AttractionFoto_IsBlob, true, context.GetImageSrcSet( sImgUrl), "HLP_AttractionSinPattern.htm");
         AssignProp("", false, imgAttractionFoto_Internalname, "URL", (String.IsNullOrEmpty(StringUtil.RTrim( A14AttractionFoto)) ? A40000AttractionFoto_GXI : context.PathToRelativeUrl( A14AttractionFoto)), true);
         AssignProp("", false, imgAttractionFoto_Internalname, "IsBlob", StringUtil.BoolToStr( A14AttractionFoto_IsBlob), true);
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtCityId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCityId_Internalname, "City Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 69,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCityId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A15CityId), 4, 0, ".", "")), StringUtil.LTrim( ((edtCityId_Enabled!=0) ? context.localUtil.Format( (decimal)(A15CityId), "ZZZ9") : context.localUtil.Format( (decimal)(A15CityId), "ZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,69);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCityId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCityId_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_AttractionSinPattern.htm");
         /* Static images/pictures */
         ClassString = "gx-prompt Image" + " " + ((StringUtil.StrCmp(imgprompt_15_gximage, "")==0) ? "" : "GX_Image_"+imgprompt_15_gximage+"_Class");
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "prompt.gif", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_15_Internalname, sImgUrl, imgprompt_15_Link, "", "", context.GetTheme( ), imgprompt_15_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_AttractionSinPattern.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtCityName_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCityName_Internalname, "City Name", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtCityName_Internalname, StringUtil.RTrim( A16CityName), StringUtil.RTrim( context.localUtil.Format( A16CityName, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCityName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCityName_Enabled, 0, "text", "", 50, "chr", 1, "row", 50, 0, 0, 0, 0, -1, -1, true, "Name", "start", true, "", "HLP_AttractionSinPattern.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__actions--fixed", "end", "Middle", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group", "start", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 79,'',false,'',0)\"";
         ClassString = "Button button-primary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", bttBtn_enter_Caption, bttBtn_enter_Jsonclick, 5, bttBtn_enter_Tooltiptext, "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_AttractionSinPattern.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 81,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancel", bttBtn_cancel_Jsonclick, 1, "Cancel", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_AttractionSinPattern.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 83,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Delete", bttBtn_delete_Jsonclick, 5, "Delete", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_AttractionSinPattern.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "end", "Middle", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
      }

      protected void UserMain( )
      {
         standaloneStartup( ) ;
      }

      protected void UserMainFullajax( )
      {
         INITENV( ) ;
         INITTRN( ) ;
         UserMain( ) ;
         Draw( ) ;
         SendCloseFormHiddens( ) ;
      }

      protected void standaloneStartup( )
      {
         standaloneStartupServer( ) ;
         disable_std_buttons( ) ;
         enableDisable( ) ;
         Process( ) ;
      }

      protected void standaloneStartupServer( )
      {
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E110A2 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               /* Read saved values. */
               Z7AttractionId = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z7AttractionId"), ".", ","), 18, MidpointRounding.ToEven));
               Z8AttractionName = cgiGet( "Z8AttractionName");
               Z9CountryId = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z9CountryId"), ".", ","), 18, MidpointRounding.ToEven));
               n9CountryId = ((0==A9CountryId) ? true : false);
               Z15CityId = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z15CityId"), ".", ","), 18, MidpointRounding.ToEven));
               n15CityId = ((0==A15CityId) ? true : false);
               Z12CategoryId = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z12CategoryId"), ".", ","), 18, MidpointRounding.ToEven));
               n12CategoryId = ((0==A12CategoryId) ? true : false);
               IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","), 18, MidpointRounding.ToEven));
               IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","), 18, MidpointRounding.ToEven));
               Gx_mode = cgiGet( "Mode");
               A40000AttractionFoto_GXI = cgiGet( "ATTRACTIONFOTO_GXI");
               AV16Pgmname = cgiGet( "vPGMNAME");
               /* Read variables values. */
               if ( ( ( context.localUtil.CToN( cgiGet( edtAttractionId_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtAttractionId_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "ATTRACTIONID");
                  AnyError = 1;
                  GX_FocusControl = edtAttractionId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A7AttractionId = 0;
                  AssignAttri("", false, "A7AttractionId", StringUtil.LTrimStr( (decimal)(A7AttractionId), 4, 0));
               }
               else
               {
                  A7AttractionId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtAttractionId_Internalname), ".", ","), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A7AttractionId", StringUtil.LTrimStr( (decimal)(A7AttractionId), 4, 0));
               }
               A8AttractionName = cgiGet( edtAttractionName_Internalname);
               AssignAttri("", false, "A8AttractionName", A8AttractionName);
               if ( ( ( context.localUtil.CToN( cgiGet( edtCountryId_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtCountryId_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "COUNTRYID");
                  AnyError = 1;
                  GX_FocusControl = edtCountryId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A9CountryId = 0;
                  n9CountryId = false;
                  AssignAttri("", false, "A9CountryId", StringUtil.LTrimStr( (decimal)(A9CountryId), 4, 0));
               }
               else
               {
                  A9CountryId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtCountryId_Internalname), ".", ","), 18, MidpointRounding.ToEven));
                  n9CountryId = false;
                  AssignAttri("", false, "A9CountryId", StringUtil.LTrimStr( (decimal)(A9CountryId), 4, 0));
               }
               n9CountryId = ((0==A9CountryId) ? true : false);
               A10CountryName = cgiGet( edtCountryName_Internalname);
               AssignAttri("", false, "A10CountryName", A10CountryName);
               if ( ( ( context.localUtil.CToN( cgiGet( edtCategoryId_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtCategoryId_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "CATEGORYID");
                  AnyError = 1;
                  GX_FocusControl = edtCategoryId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A12CategoryId = 0;
                  n12CategoryId = false;
                  AssignAttri("", false, "A12CategoryId", StringUtil.LTrimStr( (decimal)(A12CategoryId), 4, 0));
               }
               else
               {
                  A12CategoryId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtCategoryId_Internalname), ".", ","), 18, MidpointRounding.ToEven));
                  n12CategoryId = false;
                  AssignAttri("", false, "A12CategoryId", StringUtil.LTrimStr( (decimal)(A12CategoryId), 4, 0));
               }
               n12CategoryId = ((0==A12CategoryId) ? true : false);
               A13CategoryName = cgiGet( edtCategoryName_Internalname);
               AssignAttri("", false, "A13CategoryName", A13CategoryName);
               A14AttractionFoto = cgiGet( imgAttractionFoto_Internalname);
               AssignAttri("", false, "A14AttractionFoto", A14AttractionFoto);
               if ( ( ( context.localUtil.CToN( cgiGet( edtCityId_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtCityId_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "CITYID");
                  AnyError = 1;
                  GX_FocusControl = edtCityId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A15CityId = 0;
                  n15CityId = false;
                  AssignAttri("", false, "A15CityId", StringUtil.LTrimStr( (decimal)(A15CityId), 4, 0));
               }
               else
               {
                  A15CityId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtCityId_Internalname), ".", ","), 18, MidpointRounding.ToEven));
                  n15CityId = false;
                  AssignAttri("", false, "A15CityId", StringUtil.LTrimStr( (decimal)(A15CityId), 4, 0));
               }
               n15CityId = ((0==A15CityId) ? true : false);
               A16CityName = cgiGet( edtCityName_Internalname);
               AssignAttri("", false, "A16CityName", A16CityName);
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               getMultimediaValue(imgAttractionFoto_Internalname, ref  A14AttractionFoto, ref  A40000AttractionFoto_GXI);
               GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
               standaloneNotModal( ) ;
            }
            else
            {
               standaloneNotModal( ) ;
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") == 0 )
               {
                  Gx_mode = "DSP";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  A7AttractionId = (short)(Math.Round(NumberUtil.Val( GetPar( "AttractionId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A7AttractionId", StringUtil.LTrimStr( (decimal)(A7AttractionId), 4, 0));
                  getEqualNoModal( ) ;
                  Gx_mode = "DSP";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  disable_std_buttons_dsp( ) ;
                  standaloneModal( ) ;
               }
               else
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  standaloneModal( ) ;
               }
            }
         }
      }

      protected void Process( )
      {
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read Transaction buttons. */
            sEvt = cgiGet( "_EventName");
            EvtGridId = cgiGet( "_EventGridId");
            EvtRowId = cgiGet( "_EventRowId");
            if ( StringUtil.Len( sEvt) > 0 )
            {
               sEvtType = StringUtil.Left( sEvt, 1);
               sEvt = StringUtil.Right( sEvt, (short)(StringUtil.Len( sEvt)-1));
               if ( StringUtil.StrCmp(sEvtType, "M") != 0 )
               {
                  if ( StringUtil.StrCmp(sEvtType, "E") == 0 )
                  {
                     sEvtType = StringUtil.Right( sEvt, 1);
                     if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                     {
                        sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                        if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: Start */
                           E110A2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E120A2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_enter( ) ;
                           /* No code required for Cancel button. It is implemented as the Reset button. */
                        }
                        else if ( StringUtil.StrCmp(sEvt, "FIRST") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_first( ) ;
                        }
                        else if ( StringUtil.StrCmp(sEvt, "PREVIOUS") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_previous( ) ;
                        }
                        else if ( StringUtil.StrCmp(sEvt, "NEXT") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_next( ) ;
                        }
                        else if ( StringUtil.StrCmp(sEvt, "LAST") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_last( ) ;
                        }
                        else if ( StringUtil.StrCmp(sEvt, "SELECT") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_select( ) ;
                        }
                        else if ( StringUtil.StrCmp(sEvt, "DELETE") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_delete( ) ;
                        }
                        else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                        {
                           context.wbHandled = 1;
                           AfterKeyLoadScreen( ) ;
                        }
                     }
                     else
                     {
                     }
                  }
                  context.wbHandled = 1;
               }
            }
         }
      }

      protected void AfterTrn( )
      {
         if ( trnEnded == 1 )
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( endTrnMsgTxt)) )
            {
               GX_msglist.addItem(endTrnMsgTxt, endTrnMsgCod, 0, "", true);
            }
            /* Execute user event: After Trn */
            E120A2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll0A2( ) ;
               standaloneNotModal( ) ;
               standaloneModal( ) ;
            }
         }
         endTrnMsgTxt = "";
      }

      public override string ToString( )
      {
         return "" ;
      }

      public GxContentInfo GetContentInfo( )
      {
         return (GxContentInfo)(null) ;
      }

      protected void disable_std_buttons( )
      {
         if ( IsIns( ) )
         {
            bttBtn_delete_Enabled = 0;
            AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         }
      }

      protected void disable_std_buttons_dsp( )
      {
         bttBtn_delete_Visible = 0;
         AssignProp("", false, bttBtn_delete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Visible), 5, 0), true);
         bttBtn_first_Visible = 0;
         AssignProp("", false, bttBtn_first_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_first_Visible), 5, 0), true);
         bttBtn_previous_Visible = 0;
         AssignProp("", false, bttBtn_previous_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_previous_Visible), 5, 0), true);
         bttBtn_next_Visible = 0;
         AssignProp("", false, bttBtn_next_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_next_Visible), 5, 0), true);
         bttBtn_last_Visible = 0;
         AssignProp("", false, bttBtn_last_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_last_Visible), 5, 0), true);
         bttBtn_select_Visible = 0;
         AssignProp("", false, bttBtn_select_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_select_Visible), 5, 0), true);
         bttBtn_delete_Visible = 0;
         AssignProp("", false, bttBtn_delete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Visible), 5, 0), true);
         if ( IsDsp( ) )
         {
            bttBtn_enter_Visible = 0;
            AssignProp("", false, bttBtn_enter_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Visible), 5, 0), true);
         }
         DisableAttributes0A2( ) ;
      }

      protected void set_caption( )
      {
         if ( ( IsConfirmed == 1 ) && ( AnyError == 0 ) )
         {
            if ( IsDlt( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_confdelete", ""), 0, "", true);
            }
            else
            {
               GX_msglist.addItem(context.GetMessage( "GXM_mustconfirm", ""), 0, "", true);
            }
         }
      }

      protected void ResetCaption0A0( )
      {
      }

      protected void E110A2( )
      {
         /* Start Routine */
         returnInSub = false;
         if ( ! new GeneXus.Programs.general.security.isauthorized(context).executeUdp(  AV16Pgmname) )
         {
            CallWebObject(formatLink("general.security.notauthorized.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV16Pgmname))}, new string[] {"GxObject"}) );
            context.wjLocDisableFrm = 1;
         }
         AV9TrnContext.FromXml(AV10WebSession.Get("TrnContext"), null, "", "");
         AV11Insert_CountryId = 0;
         AssignAttri("", false, "AV11Insert_CountryId", StringUtil.LTrimStr( (decimal)(AV11Insert_CountryId), 4, 0));
         AV12Insert_CategoryId = 0;
         AssignAttri("", false, "AV12Insert_CategoryId", StringUtil.LTrimStr( (decimal)(AV12Insert_CategoryId), 4, 0));
         AV13Insert_CityId = 0;
         AssignAttri("", false, "AV13Insert_CityId", StringUtil.LTrimStr( (decimal)(AV13Insert_CityId), 4, 0));
         if ( ( StringUtil.StrCmp(AV9TrnContext.gxTpr_Transactionname, AV16Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV17GXV1 = 1;
            AssignAttri("", false, "AV17GXV1", StringUtil.LTrimStr( (decimal)(AV17GXV1), 8, 0));
            while ( AV17GXV1 <= AV9TrnContext.gxTpr_Attributes.Count )
            {
               AV14TrnContextAtt = ((GeneXus.Programs.general.ui.SdtTransactionContext_Attribute)AV9TrnContext.gxTpr_Attributes.Item(AV17GXV1));
               if ( StringUtil.StrCmp(AV14TrnContextAtt.gxTpr_Attributename, "CountryId") == 0 )
               {
                  AV11Insert_CountryId = (short)(Math.Round(NumberUtil.Val( AV14TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV11Insert_CountryId", StringUtil.LTrimStr( (decimal)(AV11Insert_CountryId), 4, 0));
               }
               else if ( StringUtil.StrCmp(AV14TrnContextAtt.gxTpr_Attributename, "CategoryId") == 0 )
               {
                  AV12Insert_CategoryId = (short)(Math.Round(NumberUtil.Val( AV14TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV12Insert_CategoryId", StringUtil.LTrimStr( (decimal)(AV12Insert_CategoryId), 4, 0));
               }
               else if ( StringUtil.StrCmp(AV14TrnContextAtt.gxTpr_Attributename, "CityId") == 0 )
               {
                  AV13Insert_CityId = (short)(Math.Round(NumberUtil.Val( AV14TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV13Insert_CityId", StringUtil.LTrimStr( (decimal)(AV13Insert_CityId), 4, 0));
               }
               AV17GXV1 = (int)(AV17GXV1+1);
               AssignAttri("", false, "AV17GXV1", StringUtil.LTrimStr( (decimal)(AV17GXV1), 8, 0));
            }
         }
         if ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 )
         {
            bttBtn_enter_Caption = "Delete";
            AssignProp("", false, bttBtn_enter_Internalname, "Caption", bttBtn_enter_Caption, true);
            bttBtn_enter_Tooltiptext = "Delete";
            AssignProp("", false, bttBtn_enter_Internalname, "Tooltiptext", bttBtn_enter_Tooltiptext, true);
         }
      }

      protected void E120A2( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV9TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("wwattraction.aspx") );
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         pr_default.close(1);
         pr_default.close(2);
         pr_default.close(3);
         pr_default.close(4);
         returnInSub = true;
         if (true) return;
      }

      protected void ZM0A2( short GX_JID )
      {
         if ( ( GX_JID == 4 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z8AttractionName = T000A3_A8AttractionName[0];
               Z9CountryId = T000A3_A9CountryId[0];
               Z15CityId = T000A3_A15CityId[0];
               Z12CategoryId = T000A3_A12CategoryId[0];
            }
            else
            {
               Z8AttractionName = A8AttractionName;
               Z9CountryId = A9CountryId;
               Z15CityId = A15CityId;
               Z12CategoryId = A12CategoryId;
            }
         }
         if ( GX_JID == -4 )
         {
            Z7AttractionId = A7AttractionId;
            Z8AttractionName = A8AttractionName;
            Z14AttractionFoto = A14AttractionFoto;
            Z40000AttractionFoto_GXI = A40000AttractionFoto_GXI;
            Z9CountryId = A9CountryId;
            Z15CityId = A15CityId;
            Z12CategoryId = A12CategoryId;
            Z10CountryName = A10CountryName;
            Z13CategoryName = A13CategoryName;
            Z16CityName = A16CityName;
         }
      }

      protected void standaloneNotModal( )
      {
         imgprompt_9_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"gx0030.aspx"+"',["+"{Ctrl:gx.dom.el('"+"COUNTRYID"+"'), id:'"+"COUNTRYID"+"'"+",IOType:'out'}"+"],"+"null"+","+"'', false"+","+"false"+");");
         imgprompt_12_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"gx0040.aspx"+"',["+"{Ctrl:gx.dom.el('"+"CATEGORYID"+"'), id:'"+"CATEGORYID"+"'"+",IOType:'out'}"+"],"+"null"+","+"'', false"+","+"false"+");");
         imgprompt_15_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"gx0051.aspx"+"',["+"{Ctrl:gx.dom.el('"+"COUNTRYID"+"'), id:'"+"COUNTRYID"+"'"+",IOType:'in'}"+","+"{Ctrl:gx.dom.el('"+"CITYID"+"'), id:'"+"CITYID"+"'"+",IOType:'out'}"+"],"+"null"+","+"'', false"+","+"false"+");");
      }

      protected void standaloneModal( )
      {
         if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
         {
            bttBtn_delete_Enabled = 0;
            AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         }
         else
         {
            bttBtn_delete_Enabled = 1;
            AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         }
         if ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 )
         {
            bttBtn_enter_Enabled = 0;
            AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         }
         else
         {
            bttBtn_enter_Enabled = 1;
            AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         }
      }

      protected void Load0A2( )
      {
         /* Using cursor T000A7 */
         pr_default.execute(5, new Object[] {A7AttractionId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound2 = 1;
            A8AttractionName = T000A7_A8AttractionName[0];
            AssignAttri("", false, "A8AttractionName", A8AttractionName);
            A10CountryName = T000A7_A10CountryName[0];
            AssignAttri("", false, "A10CountryName", A10CountryName);
            A13CategoryName = T000A7_A13CategoryName[0];
            AssignAttri("", false, "A13CategoryName", A13CategoryName);
            A40000AttractionFoto_GXI = T000A7_A40000AttractionFoto_GXI[0];
            AssignProp("", false, imgAttractionFoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A14AttractionFoto)) ? A40000AttractionFoto_GXI : context.convertURL( context.PathToRelativeUrl( A14AttractionFoto))), true);
            AssignProp("", false, imgAttractionFoto_Internalname, "SrcSet", context.GetImageSrcSet( A14AttractionFoto), true);
            A16CityName = T000A7_A16CityName[0];
            AssignAttri("", false, "A16CityName", A16CityName);
            A9CountryId = T000A7_A9CountryId[0];
            n9CountryId = T000A7_n9CountryId[0];
            AssignAttri("", false, "A9CountryId", StringUtil.LTrimStr( (decimal)(A9CountryId), 4, 0));
            A15CityId = T000A7_A15CityId[0];
            n15CityId = T000A7_n15CityId[0];
            AssignAttri("", false, "A15CityId", StringUtil.LTrimStr( (decimal)(A15CityId), 4, 0));
            A12CategoryId = T000A7_A12CategoryId[0];
            n12CategoryId = T000A7_n12CategoryId[0];
            AssignAttri("", false, "A12CategoryId", StringUtil.LTrimStr( (decimal)(A12CategoryId), 4, 0));
            A14AttractionFoto = T000A7_A14AttractionFoto[0];
            AssignAttri("", false, "A14AttractionFoto", A14AttractionFoto);
            AssignProp("", false, imgAttractionFoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A14AttractionFoto)) ? A40000AttractionFoto_GXI : context.convertURL( context.PathToRelativeUrl( A14AttractionFoto))), true);
            AssignProp("", false, imgAttractionFoto_Internalname, "SrcSet", context.GetImageSrcSet( A14AttractionFoto), true);
            ZM0A2( -4) ;
         }
         pr_default.close(5);
         OnLoadActions0A2( ) ;
      }

      protected void OnLoadActions0A2( )
      {
         AV16Pgmname = "AttractionSinPattern";
         AssignAttri("", false, "AV16Pgmname", AV16Pgmname);
      }

      protected void CheckExtendedTable0A2( )
      {
         Gx_BScreen = 1;
         standaloneModal( ) ;
         AV16Pgmname = "AttractionSinPattern";
         AssignAttri("", false, "AV16Pgmname", AV16Pgmname);
         /* Using cursor T000A8 */
         pr_default.execute(6, new Object[] {A8AttractionName, A7AttractionId});
         if ( (pr_default.getStatus(6) != 101) )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_1004", new   object[]  {"Attraction Name"}), 1, "ATTRACTIONNAME");
            AnyError = 1;
            GX_FocusControl = edtAttractionName_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(6);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A8AttractionName)) )
         {
            GX_msglist.addItem("no deberia ser vacio ", 1, "ATTRACTIONNAME");
            AnyError = 1;
            GX_FocusControl = edtAttractionName_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         /* Using cursor T000A4 */
         pr_default.execute(2, new Object[] {n9CountryId, A9CountryId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            if ( ! ( (0==A9CountryId) ) )
            {
               GX_msglist.addItem("No matching 'Country'.", "ForeignKeyNotFound", 1, "COUNTRYID");
               AnyError = 1;
               GX_FocusControl = edtCountryId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A10CountryName = T000A4_A10CountryName[0];
         AssignAttri("", false, "A10CountryName", A10CountryName);
         pr_default.close(2);
         /* Using cursor T000A5 */
         pr_default.execute(3, new Object[] {n9CountryId, A9CountryId, n15CityId, A15CityId});
         if ( (pr_default.getStatus(3) == 101) )
         {
            if ( ! ( (0==A9CountryId) || (0==A15CityId) ) )
            {
               GX_msglist.addItem("No matching 'City'.", "ForeignKeyNotFound", 1, "CITYID");
               AnyError = 1;
               GX_FocusControl = edtCountryId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A16CityName = T000A5_A16CityName[0];
         AssignAttri("", false, "A16CityName", A16CityName);
         pr_default.close(3);
         /* Using cursor T000A6 */
         pr_default.execute(4, new Object[] {n12CategoryId, A12CategoryId});
         if ( (pr_default.getStatus(4) == 101) )
         {
            if ( ! ( (0==A12CategoryId) ) )
            {
               GX_msglist.addItem("No matching 'Category'.", "ForeignKeyNotFound", 1, "CATEGORYID");
               AnyError = 1;
               GX_FocusControl = edtCategoryId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A13CategoryName = T000A6_A13CategoryName[0];
         AssignAttri("", false, "A13CategoryName", A13CategoryName);
         pr_default.close(4);
      }

      protected void CloseExtendedTableCursors0A2( )
      {
         pr_default.close(2);
         pr_default.close(3);
         pr_default.close(4);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_6( short A9CountryId )
      {
         /* Using cursor T000A9 */
         pr_default.execute(7, new Object[] {n9CountryId, A9CountryId});
         if ( (pr_default.getStatus(7) == 101) )
         {
            if ( ! ( (0==A9CountryId) ) )
            {
               GX_msglist.addItem("No matching 'Country'.", "ForeignKeyNotFound", 1, "COUNTRYID");
               AnyError = 1;
               GX_FocusControl = edtCountryId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A10CountryName = T000A9_A10CountryName[0];
         AssignAttri("", false, "A10CountryName", A10CountryName);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A10CountryName))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(7) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(7);
      }

      protected void gxLoad_7( short A9CountryId ,
                               short A15CityId )
      {
         /* Using cursor T000A10 */
         pr_default.execute(8, new Object[] {n9CountryId, A9CountryId, n15CityId, A15CityId});
         if ( (pr_default.getStatus(8) == 101) )
         {
            if ( ! ( (0==A9CountryId) || (0==A15CityId) ) )
            {
               GX_msglist.addItem("No matching 'City'.", "ForeignKeyNotFound", 1, "CITYID");
               AnyError = 1;
               GX_FocusControl = edtCountryId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A16CityName = T000A10_A16CityName[0];
         AssignAttri("", false, "A16CityName", A16CityName);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A16CityName))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(8) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(8);
      }

      protected void gxLoad_8( short A12CategoryId )
      {
         /* Using cursor T000A11 */
         pr_default.execute(9, new Object[] {n12CategoryId, A12CategoryId});
         if ( (pr_default.getStatus(9) == 101) )
         {
            if ( ! ( (0==A12CategoryId) ) )
            {
               GX_msglist.addItem("No matching 'Category'.", "ForeignKeyNotFound", 1, "CATEGORYID");
               AnyError = 1;
               GX_FocusControl = edtCategoryId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A13CategoryName = T000A11_A13CategoryName[0];
         AssignAttri("", false, "A13CategoryName", A13CategoryName);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A13CategoryName))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(9) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(9);
      }

      protected void GetKey0A2( )
      {
         /* Using cursor T000A12 */
         pr_default.execute(10, new Object[] {A7AttractionId});
         if ( (pr_default.getStatus(10) != 101) )
         {
            RcdFound2 = 1;
         }
         else
         {
            RcdFound2 = 0;
         }
         pr_default.close(10);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T000A3 */
         pr_default.execute(1, new Object[] {A7AttractionId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0A2( 4) ;
            RcdFound2 = 1;
            A7AttractionId = T000A3_A7AttractionId[0];
            AssignAttri("", false, "A7AttractionId", StringUtil.LTrimStr( (decimal)(A7AttractionId), 4, 0));
            A8AttractionName = T000A3_A8AttractionName[0];
            AssignAttri("", false, "A8AttractionName", A8AttractionName);
            A40000AttractionFoto_GXI = T000A3_A40000AttractionFoto_GXI[0];
            AssignProp("", false, imgAttractionFoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A14AttractionFoto)) ? A40000AttractionFoto_GXI : context.convertURL( context.PathToRelativeUrl( A14AttractionFoto))), true);
            AssignProp("", false, imgAttractionFoto_Internalname, "SrcSet", context.GetImageSrcSet( A14AttractionFoto), true);
            A9CountryId = T000A3_A9CountryId[0];
            n9CountryId = T000A3_n9CountryId[0];
            AssignAttri("", false, "A9CountryId", StringUtil.LTrimStr( (decimal)(A9CountryId), 4, 0));
            A15CityId = T000A3_A15CityId[0];
            n15CityId = T000A3_n15CityId[0];
            AssignAttri("", false, "A15CityId", StringUtil.LTrimStr( (decimal)(A15CityId), 4, 0));
            A12CategoryId = T000A3_A12CategoryId[0];
            n12CategoryId = T000A3_n12CategoryId[0];
            AssignAttri("", false, "A12CategoryId", StringUtil.LTrimStr( (decimal)(A12CategoryId), 4, 0));
            A14AttractionFoto = T000A3_A14AttractionFoto[0];
            AssignAttri("", false, "A14AttractionFoto", A14AttractionFoto);
            AssignProp("", false, imgAttractionFoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A14AttractionFoto)) ? A40000AttractionFoto_GXI : context.convertURL( context.PathToRelativeUrl( A14AttractionFoto))), true);
            AssignProp("", false, imgAttractionFoto_Internalname, "SrcSet", context.GetImageSrcSet( A14AttractionFoto), true);
            Z7AttractionId = A7AttractionId;
            sMode2 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load0A2( ) ;
            if ( AnyError == 1 )
            {
               RcdFound2 = 0;
               InitializeNonKey0A2( ) ;
            }
            Gx_mode = sMode2;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound2 = 0;
            InitializeNonKey0A2( ) ;
            sMode2 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode2;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0A2( ) ;
         if ( RcdFound2 == 0 )
         {
            Gx_mode = "INS";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound2 = 0;
         /* Using cursor T000A13 */
         pr_default.execute(11, new Object[] {A7AttractionId});
         if ( (pr_default.getStatus(11) != 101) )
         {
            while ( (pr_default.getStatus(11) != 101) && ( ( T000A13_A7AttractionId[0] < A7AttractionId ) ) )
            {
               pr_default.readNext(11);
            }
            if ( (pr_default.getStatus(11) != 101) && ( ( T000A13_A7AttractionId[0] > A7AttractionId ) ) )
            {
               A7AttractionId = T000A13_A7AttractionId[0];
               AssignAttri("", false, "A7AttractionId", StringUtil.LTrimStr( (decimal)(A7AttractionId), 4, 0));
               RcdFound2 = 1;
            }
         }
         pr_default.close(11);
      }

      protected void move_previous( )
      {
         RcdFound2 = 0;
         /* Using cursor T000A14 */
         pr_default.execute(12, new Object[] {A7AttractionId});
         if ( (pr_default.getStatus(12) != 101) )
         {
            while ( (pr_default.getStatus(12) != 101) && ( ( T000A14_A7AttractionId[0] > A7AttractionId ) ) )
            {
               pr_default.readNext(12);
            }
            if ( (pr_default.getStatus(12) != 101) && ( ( T000A14_A7AttractionId[0] < A7AttractionId ) ) )
            {
               A7AttractionId = T000A14_A7AttractionId[0];
               AssignAttri("", false, "A7AttractionId", StringUtil.LTrimStr( (decimal)(A7AttractionId), 4, 0));
               RcdFound2 = 1;
            }
         }
         pr_default.close(12);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey0A2( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtAttractionId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert0A2( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound2 == 1 )
            {
               if ( A7AttractionId != Z7AttractionId )
               {
                  A7AttractionId = Z7AttractionId;
                  AssignAttri("", false, "A7AttractionId", StringUtil.LTrimStr( (decimal)(A7AttractionId), 4, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "ATTRACTIONID");
                  AnyError = 1;
                  GX_FocusControl = edtAttractionId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtAttractionId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update0A2( ) ;
                  GX_FocusControl = edtAttractionId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A7AttractionId != Z7AttractionId )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtAttractionId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert0A2( ) ;
                  if ( AnyError == 1 )
                  {
                     GX_FocusControl = "";
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
               }
               else
               {
                  if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "ATTRACTIONID");
                     AnyError = 1;
                     GX_FocusControl = edtAttractionId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtAttractionId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert0A2( ) ;
                     if ( AnyError == 1 )
                     {
                        GX_FocusControl = "";
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
         }
         AfterTrn( ) ;
      }

      protected void btn_delete( )
      {
         if ( A7AttractionId != Z7AttractionId )
         {
            A7AttractionId = Z7AttractionId;
            AssignAttri("", false, "A7AttractionId", StringUtil.LTrimStr( (decimal)(A7AttractionId), 4, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "ATTRACTIONID");
            AnyError = 1;
            GX_FocusControl = edtAttractionId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtAttractionId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            getByPrimaryKey( ) ;
         }
         CloseCursors();
      }

      protected void btn_get( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         getEqualNoModal( ) ;
         if ( RcdFound2 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "ATTRACTIONID");
            AnyError = 1;
            GX_FocusControl = edtAttractionId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtAttractionName_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart0A2( ) ;
         if ( RcdFound2 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtAttractionName_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd0A2( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_previous( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         move_previous( ) ;
         if ( RcdFound2 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtAttractionName_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_next( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         move_next( ) ;
         if ( RcdFound2 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtAttractionName_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_last( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart0A2( ) ;
         if ( RcdFound2 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound2 != 0 )
            {
               ScanNext0A2( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtAttractionName_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd0A2( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency0A2( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T000A2 */
            pr_default.execute(0, new Object[] {A7AttractionId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Attraction"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z8AttractionName, T000A2_A8AttractionName[0]) != 0 ) || ( Z9CountryId != T000A2_A9CountryId[0] ) || ( Z15CityId != T000A2_A15CityId[0] ) || ( Z12CategoryId != T000A2_A12CategoryId[0] ) )
            {
               if ( StringUtil.StrCmp(Z8AttractionName, T000A2_A8AttractionName[0]) != 0 )
               {
                  GXUtil.WriteLog("attractionsinpattern:[seudo value changed for attri]"+"AttractionName");
                  GXUtil.WriteLogRaw("Old: ",Z8AttractionName);
                  GXUtil.WriteLogRaw("Current: ",T000A2_A8AttractionName[0]);
               }
               if ( Z9CountryId != T000A2_A9CountryId[0] )
               {
                  GXUtil.WriteLog("attractionsinpattern:[seudo value changed for attri]"+"CountryId");
                  GXUtil.WriteLogRaw("Old: ",Z9CountryId);
                  GXUtil.WriteLogRaw("Current: ",T000A2_A9CountryId[0]);
               }
               if ( Z15CityId != T000A2_A15CityId[0] )
               {
                  GXUtil.WriteLog("attractionsinpattern:[seudo value changed for attri]"+"CityId");
                  GXUtil.WriteLogRaw("Old: ",Z15CityId);
                  GXUtil.WriteLogRaw("Current: ",T000A2_A15CityId[0]);
               }
               if ( Z12CategoryId != T000A2_A12CategoryId[0] )
               {
                  GXUtil.WriteLog("attractionsinpattern:[seudo value changed for attri]"+"CategoryId");
                  GXUtil.WriteLogRaw("Old: ",Z12CategoryId);
                  GXUtil.WriteLogRaw("Current: ",T000A2_A12CategoryId[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Attraction"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0A2( )
      {
         BeforeValidate0A2( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0A2( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0A2( 0) ;
            CheckOptimisticConcurrency0A2( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0A2( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0A2( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000A15 */
                     pr_default.execute(13, new Object[] {A8AttractionName, A14AttractionFoto, A40000AttractionFoto_GXI, n9CountryId, A9CountryId, n15CityId, A15CityId, n12CategoryId, A12CategoryId});
                     A7AttractionId = T000A15_A7AttractionId[0];
                     AssignAttri("", false, "A7AttractionId", StringUtil.LTrimStr( (decimal)(A7AttractionId), 4, 0));
                     pr_default.close(13);
                     pr_default.SmartCacheProvider.SetUpdated("Attraction");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption0A0( ) ;
                        }
                     }
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                     AnyError = 1;
                  }
               }
            }
            else
            {
               Load0A2( ) ;
            }
            EndLevel0A2( ) ;
         }
         CloseExtendedTableCursors0A2( ) ;
      }

      protected void Update0A2( )
      {
         BeforeValidate0A2( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0A2( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0A2( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0A2( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0A2( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000A16 */
                     pr_default.execute(14, new Object[] {A8AttractionName, n9CountryId, A9CountryId, n15CityId, A15CityId, n12CategoryId, A12CategoryId, A7AttractionId});
                     pr_default.close(14);
                     pr_default.SmartCacheProvider.SetUpdated("Attraction");
                     if ( (pr_default.getStatus(14) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Attraction"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0A2( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption0A0( ) ;
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                        AnyError = 1;
                     }
                  }
               }
            }
            EndLevel0A2( ) ;
         }
         CloseExtendedTableCursors0A2( ) ;
      }

      protected void DeferredUpdate0A2( )
      {
         if ( AnyError == 0 )
         {
            /* Using cursor T000A17 */
            pr_default.execute(15, new Object[] {A14AttractionFoto, A40000AttractionFoto_GXI, A7AttractionId});
            pr_default.close(15);
            pr_default.SmartCacheProvider.SetUpdated("Attraction");
         }
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate0A2( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0A2( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0A2( ) ;
            AfterConfirm0A2( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0A2( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000A18 */
                  pr_default.execute(16, new Object[] {A7AttractionId});
                  pr_default.close(16);
                  pr_default.SmartCacheProvider.SetUpdated("Attraction");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound2 == 0 )
                        {
                           InitAll0A2( ) ;
                           Gx_mode = "INS";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                        }
                        else
                        {
                           getByPrimaryKey( ) ;
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                        }
                        endTrnMsgTxt = context.GetMessage( "GXM_sucdeleted", "");
                        endTrnMsgCod = "SuccessfullyDeleted";
                        ResetCaption0A0( ) ;
                     }
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                     AnyError = 1;
                  }
               }
            }
         }
         sMode2 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel0A2( ) ;
         Gx_mode = sMode2;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0A2( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            AV16Pgmname = "AttractionSinPattern";
            AssignAttri("", false, "AV16Pgmname", AV16Pgmname);
            /* Using cursor T000A19 */
            pr_default.execute(17, new Object[] {n9CountryId, A9CountryId});
            A10CountryName = T000A19_A10CountryName[0];
            AssignAttri("", false, "A10CountryName", A10CountryName);
            pr_default.close(17);
            /* Using cursor T000A20 */
            pr_default.execute(18, new Object[] {n12CategoryId, A12CategoryId});
            A13CategoryName = T000A20_A13CategoryName[0];
            AssignAttri("", false, "A13CategoryName", A13CategoryName);
            pr_default.close(18);
            /* Using cursor T000A21 */
            pr_default.execute(19, new Object[] {n9CountryId, A9CountryId, n15CityId, A15CityId});
            A16CityName = T000A21_A16CityName[0];
            AssignAttri("", false, "A16CityName", A16CityName);
            pr_default.close(19);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor T000A22 */
            pr_default.execute(20, new Object[] {A7AttractionId});
            if ( (pr_default.getStatus(20) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Attraction"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(20);
         }
      }

      protected void EndLevel0A2( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0A2( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            pr_default.close(17);
            pr_default.close(19);
            pr_default.close(18);
            context.CommitDataStores("attractionsinpattern",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues0A0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            pr_default.close(17);
            pr_default.close(19);
            pr_default.close(18);
            context.RollbackDataStores("attractionsinpattern",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart0A2( )
      {
         /* Scan By routine */
         /* Using cursor T000A23 */
         pr_default.execute(21);
         RcdFound2 = 0;
         if ( (pr_default.getStatus(21) != 101) )
         {
            RcdFound2 = 1;
            A7AttractionId = T000A23_A7AttractionId[0];
            AssignAttri("", false, "A7AttractionId", StringUtil.LTrimStr( (decimal)(A7AttractionId), 4, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0A2( )
      {
         /* Scan next routine */
         pr_default.readNext(21);
         RcdFound2 = 0;
         if ( (pr_default.getStatus(21) != 101) )
         {
            RcdFound2 = 1;
            A7AttractionId = T000A23_A7AttractionId[0];
            AssignAttri("", false, "A7AttractionId", StringUtil.LTrimStr( (decimal)(A7AttractionId), 4, 0));
         }
      }

      protected void ScanEnd0A2( )
      {
         pr_default.close(21);
      }

      protected void AfterConfirm0A2( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0A2( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0A2( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0A2( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0A2( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0A2( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0A2( )
      {
         edtAttractionId_Enabled = 0;
         AssignProp("", false, edtAttractionId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAttractionId_Enabled), 5, 0), true);
         edtAttractionName_Enabled = 0;
         AssignProp("", false, edtAttractionName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAttractionName_Enabled), 5, 0), true);
         edtCountryId_Enabled = 0;
         AssignProp("", false, edtCountryId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCountryId_Enabled), 5, 0), true);
         edtCountryName_Enabled = 0;
         AssignProp("", false, edtCountryName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCountryName_Enabled), 5, 0), true);
         edtCategoryId_Enabled = 0;
         AssignProp("", false, edtCategoryId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCategoryId_Enabled), 5, 0), true);
         edtCategoryName_Enabled = 0;
         AssignProp("", false, edtCategoryName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCategoryName_Enabled), 5, 0), true);
         imgAttractionFoto_Enabled = 0;
         AssignProp("", false, imgAttractionFoto_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(imgAttractionFoto_Enabled), 5, 0), true);
         edtCityId_Enabled = 0;
         AssignProp("", false, edtCityId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCityId_Enabled), 5, 0), true);
         edtCityName_Enabled = 0;
         AssignProp("", false, edtCityName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCityName_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes0A2( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues0A0( )
      {
      }

      public override void RenderHtmlHeaders( )
      {
         GxWebStd.gx_html_headers( context, 0, "", "", Form.Meta, Form.Metaequiv, true);
      }

      public override void RenderHtmlOpenForm( )
      {
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.WriteHtmlText( "<title>") ;
         context.SendWebValue( Form.Caption) ;
         context.WriteHtmlTextNl( "</title>") ;
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         if ( StringUtil.Len( sDynURL) > 0 )
         {
            context.WriteHtmlText( "<BASE href=\""+sDynURL+"\" />") ;
         }
         define_styles( ) ;
         MasterPageObj.master_styles();
         CloseStyles();
         if ( ( ( context.GetBrowserType( ) == 1 ) || ( context.GetBrowserType( ) == 5 ) ) && ( StringUtil.StrCmp(context.GetBrowserVersion( ), "7.0") == 0 ) )
         {
            context.AddJavascriptSource("json2.js", "?"+context.GetBuildNumber( 1438560), false, true);
         }
         context.AddJavascriptSource("jquery.js", "?"+context.GetBuildNumber( 1438560), false, true);
         context.AddJavascriptSource("gxgral.js", "?"+context.GetBuildNumber( 1438560), false, true);
         context.AddJavascriptSource("gxcfg.js", "?"+GetCacheInvalidationToken( ), false, true);
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.WriteHtmlText( Form.Headerrawhtml) ;
         context.CloseHtmlHeader();
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         FormProcess = " data-HasEnter=\"true\" data-Skiponenter=\"false\"";
         context.WriteHtmlText( "<body ") ;
         if ( StringUtil.StrCmp(context.GetLanguageProperty( "rtl"), "true") == 0 )
         {
            context.WriteHtmlText( " dir=\"rtl\" ") ;
         }
         bodyStyle = "" + "background-color:" + context.BuildHTMLColor( Form.Backcolor) + ";color:" + context.BuildHTMLColor( Form.Textcolor) + ";";
         bodyStyle += "-moz-opacity:0;opacity:0;";
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( Form.Background)) ) )
         {
            bodyStyle += " background-image:url(" + context.convertURL( Form.Background) + ")";
         }
         context.WriteHtmlText( " "+"class=\"form-horizontal Form\""+" "+ "style='"+bodyStyle+"'") ;
         context.WriteHtmlText( FormProcess+">") ;
         context.skipLines(1);
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("attractionsinpattern.aspx") +"\">") ;
         GxWebStd.gx_hidden_field( context, "_EventName", "");
         GxWebStd.gx_hidden_field( context, "_EventGridId", "");
         GxWebStd.gx_hidden_field( context, "_EventRowId", "");
         context.WriteHtmlText( "<div style=\"height:0;overflow:hidden\"><input type=\"submit\" title=\"submit\"  disabled></div>") ;
         AssignProp("", false, "FORM", "Class", "form-horizontal Form", true);
         toggleJsOutput = isJsOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
      }

      protected void send_integrity_footer_hashes( )
      {
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z7AttractionId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z7AttractionId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z8AttractionName", StringUtil.RTrim( Z8AttractionName));
         GxWebStd.gx_hidden_field( context, "Z9CountryId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z9CountryId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z15CityId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z15CityId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z12CategoryId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z12CategoryId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "vMODE", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_vMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vTRNCONTEXT", AV9TrnContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vTRNCONTEXT", AV9TrnContext);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vTRNCONTEXT", GetSecureSignedToken( "", AV9TrnContext, context));
         GxWebStd.gx_hidden_field( context, "ATTRACTIONFOTO_GXI", A40000AttractionFoto_GXI);
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV16Pgmname));
         GXCCtlgxBlob = "ATTRACTIONFOTO" + "_gxBlob";
         GxWebStd.gx_hidden_field( context, GXCCtlgxBlob, A14AttractionFoto);
      }

      public override void RenderHtmlCloseForm( )
      {
         SendCloseFormHiddens( ) ;
         GxWebStd.gx_hidden_field( context, "GX_FocusControl", GX_FocusControl);
         SendAjaxEncryptionKey();
         SendSecurityToken(sPrefix);
         SendComponentObjects();
         SendServerCommands();
         SendState();
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         context.WriteHtmlTextNl( "</form>") ;
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         include_jscripts( ) ;
      }

      public override short ExecuteStartEvent( )
      {
         standaloneStartup( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         return gxajaxcallmode ;
      }

      public override void RenderHtmlContent( )
      {
         context.WriteHtmlText( "<div") ;
         GxWebStd.ClassAttribute( context, "gx-ct-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal Form" : Form.Class)+"-fx");
         context.WriteHtmlText( ">") ;
         Draw( ) ;
         context.WriteHtmlText( "</div>") ;
      }

      public override void DispatchEvents( )
      {
         Process( ) ;
      }

      public override bool HasEnterEvent( )
      {
         return true ;
      }

      public override GXWebForm GetForm( )
      {
         return Form ;
      }

      public override string GetSelfLink( )
      {
         return formatLink("attractionsinpattern.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "AttractionSinPattern" ;
      }

      public override string GetPgmdesc( )
      {
         return "Attraction Sin Pattern" ;
      }

      protected void InitializeNonKey0A2( )
      {
         A8AttractionName = "";
         AssignAttri("", false, "A8AttractionName", A8AttractionName);
         A9CountryId = 0;
         n9CountryId = false;
         AssignAttri("", false, "A9CountryId", StringUtil.LTrimStr( (decimal)(A9CountryId), 4, 0));
         n9CountryId = ((0==A9CountryId) ? true : false);
         A10CountryName = "";
         AssignAttri("", false, "A10CountryName", A10CountryName);
         A12CategoryId = 0;
         n12CategoryId = false;
         AssignAttri("", false, "A12CategoryId", StringUtil.LTrimStr( (decimal)(A12CategoryId), 4, 0));
         n12CategoryId = ((0==A12CategoryId) ? true : false);
         A13CategoryName = "";
         AssignAttri("", false, "A13CategoryName", A13CategoryName);
         A14AttractionFoto = "";
         AssignAttri("", false, "A14AttractionFoto", A14AttractionFoto);
         AssignProp("", false, imgAttractionFoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A14AttractionFoto)) ? A40000AttractionFoto_GXI : context.convertURL( context.PathToRelativeUrl( A14AttractionFoto))), true);
         AssignProp("", false, imgAttractionFoto_Internalname, "SrcSet", context.GetImageSrcSet( A14AttractionFoto), true);
         A40000AttractionFoto_GXI = "";
         AssignProp("", false, imgAttractionFoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A14AttractionFoto)) ? A40000AttractionFoto_GXI : context.convertURL( context.PathToRelativeUrl( A14AttractionFoto))), true);
         AssignProp("", false, imgAttractionFoto_Internalname, "SrcSet", context.GetImageSrcSet( A14AttractionFoto), true);
         A15CityId = 0;
         n15CityId = false;
         AssignAttri("", false, "A15CityId", StringUtil.LTrimStr( (decimal)(A15CityId), 4, 0));
         n15CityId = ((0==A15CityId) ? true : false);
         A16CityName = "";
         AssignAttri("", false, "A16CityName", A16CityName);
         Z8AttractionName = "";
         Z9CountryId = 0;
         Z15CityId = 0;
         Z12CategoryId = 0;
      }

      protected void InitAll0A2( )
      {
         A7AttractionId = 0;
         AssignAttri("", false, "A7AttractionId", StringUtil.LTrimStr( (decimal)(A7AttractionId), 4, 0));
         InitializeNonKey0A2( ) ;
      }

      protected void StandaloneModalInsert( )
      {
      }

      protected void define_styles( )
      {
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202453114441212", true, true);
            idxLst = (int)(idxLst+1);
         }
         if ( ! outputEnabled )
         {
            if ( context.isSpaRequest( ) )
            {
               disableOutput();
            }
         }
         /* End function define_styles */
      }

      protected void include_jscripts( )
      {
         context.AddJavascriptSource("messages.eng.js", "?"+GetCacheInvalidationToken( ), false, true);
         context.AddJavascriptSource("attractionsinpattern.js", "?202453114441212", false, true);
         /* End function include_jscripts */
      }

      protected void init_default_properties( )
      {
         lblTitle_Internalname = "TITLE";
         divTitlecontainer_Internalname = "TITLECONTAINER";
         bttBtn_first_Internalname = "BTN_FIRST";
         bttBtn_previous_Internalname = "BTN_PREVIOUS";
         bttBtn_next_Internalname = "BTN_NEXT";
         bttBtn_last_Internalname = "BTN_LAST";
         bttBtn_select_Internalname = "BTN_SELECT";
         divToolbarcell_Internalname = "TOOLBARCELL";
         edtAttractionId_Internalname = "ATTRACTIONID";
         edtAttractionName_Internalname = "ATTRACTIONNAME";
         edtCountryId_Internalname = "COUNTRYID";
         edtCountryName_Internalname = "COUNTRYNAME";
         edtCategoryId_Internalname = "CATEGORYID";
         edtCategoryName_Internalname = "CATEGORYNAME";
         imgAttractionFoto_Internalname = "ATTRACTIONFOTO";
         edtCityId_Internalname = "CITYID";
         edtCityName_Internalname = "CITYNAME";
         divFormcontainer_Internalname = "FORMCONTAINER";
         bttBtn_enter_Internalname = "BTN_ENTER";
         bttBtn_cancel_Internalname = "BTN_CANCEL";
         bttBtn_delete_Internalname = "BTN_DELETE";
         divMaintable_Internalname = "MAINTABLE";
         Form.Internalname = "FORM";
         imgprompt_9_Internalname = "PROMPT_9";
         imgprompt_12_Internalname = "PROMPT_12";
         imgprompt_15_Internalname = "PROMPT_15";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("TravelAgency", true);
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Attraction Sin Pattern";
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Tooltiptext = "Confirm";
         bttBtn_enter_Caption = "Confirm";
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtCityName_Jsonclick = "";
         edtCityName_Enabled = 0;
         imgprompt_15_Visible = 1;
         imgprompt_15_Link = "";
         edtCityId_Jsonclick = "";
         edtCityId_Enabled = 1;
         imgAttractionFoto_Enabled = 1;
         edtCategoryName_Jsonclick = "";
         edtCategoryName_Enabled = 0;
         imgprompt_12_Visible = 1;
         imgprompt_12_Link = "";
         edtCategoryId_Jsonclick = "";
         edtCategoryId_Enabled = 1;
         edtCountryName_Jsonclick = "";
         edtCountryName_Enabled = 0;
         imgprompt_9_Visible = 1;
         imgprompt_9_Link = "";
         edtCountryId_Jsonclick = "";
         edtCountryId_Enabled = 1;
         edtAttractionName_Jsonclick = "";
         edtAttractionName_Enabled = 1;
         edtAttractionId_Jsonclick = "";
         edtAttractionId_Enabled = 1;
         bttBtn_select_Visible = 1;
         bttBtn_last_Visible = 1;
         bttBtn_next_Visible = 1;
         bttBtn_previous_Visible = 1;
         bttBtn_first_Visible = 1;
         context.GX_msglist.DisplayMode = 1;
         if ( context.isSpaRequest( ) )
         {
            enableJsOutput();
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void AfterKeyLoadScreen( )
      {
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         getEqualNoModal( ) ;
         GX_FocusControl = edtAttractionName_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
         /* End function AfterKeyLoadScreen */
      }

      protected bool IsIns( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "INS")==0) ? true : false) ;
      }

      protected bool IsDlt( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "DLT")==0) ? true : false) ;
      }

      protected bool IsUpd( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "UPD")==0) ? true : false) ;
      }

      protected bool IsDsp( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? true : false) ;
      }

      public void Valid_Attractionid( )
      {
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A8AttractionName", StringUtil.RTrim( A8AttractionName));
         AssignAttri("", false, "A9CountryId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A9CountryId), 4, 0, ".", "")));
         AssignAttri("", false, "A12CategoryId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A12CategoryId), 4, 0, ".", "")));
         AssignAttri("", false, "A14AttractionFoto", context.PathToRelativeUrl( A14AttractionFoto));
         GXCCtlgxBlob = "ATTRACTIONFOTO" + "_gxBlob";
         AssignAttri("", false, "GXCCtlgxBlob", GXCCtlgxBlob);
         GxWebStd.gx_hidden_field( context, GXCCtlgxBlob, context.PathToRelativeUrl( A14AttractionFoto));
         AssignAttri("", false, "A40000AttractionFoto_GXI", A40000AttractionFoto_GXI);
         AssignAttri("", false, "A15CityId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A15CityId), 4, 0, ".", "")));
         AssignAttri("", false, "AV16Pgmname", StringUtil.RTrim( AV16Pgmname));
         AssignAttri("", false, "A10CountryName", StringUtil.RTrim( A10CountryName));
         AssignAttri("", false, "A16CityName", StringUtil.RTrim( A16CityName));
         AssignAttri("", false, "A13CategoryName", StringUtil.RTrim( A13CategoryName));
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z7AttractionId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z7AttractionId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z8AttractionName", StringUtil.RTrim( Z8AttractionName));
         GxWebStd.gx_hidden_field( context, "Z9CountryId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z9CountryId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z12CategoryId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z12CategoryId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z14AttractionFoto", context.PathToRelativeUrl( Z14AttractionFoto));
         GxWebStd.gx_hidden_field( context, "Z40000AttractionFoto_GXI", Z40000AttractionFoto_GXI);
         GxWebStd.gx_hidden_field( context, "Z15CityId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z15CityId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "ZV16Pgmname", StringUtil.RTrim( ZV16Pgmname));
         GxWebStd.gx_hidden_field( context, "Z10CountryName", StringUtil.RTrim( Z10CountryName));
         GxWebStd.gx_hidden_field( context, "Z16CityName", StringUtil.RTrim( Z16CityName));
         GxWebStd.gx_hidden_field( context, "Z13CategoryName", StringUtil.RTrim( Z13CategoryName));
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         SendCloseFormHiddens( ) ;
      }

      public void Valid_Attractionname( )
      {
         /* Using cursor T000A24 */
         pr_default.execute(22, new Object[] {A8AttractionName, A7AttractionId});
         if ( (pr_default.getStatus(22) != 101) )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_1004", new   object[]  {"Attraction Name"}), 1, "ATTRACTIONNAME");
            AnyError = 1;
            GX_FocusControl = edtAttractionName_Internalname;
         }
         pr_default.close(22);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A8AttractionName)) )
         {
            GX_msglist.addItem("no deberia ser vacio ", 1, "ATTRACTIONNAME");
            AnyError = 1;
            GX_FocusControl = edtAttractionName_Internalname;
         }
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public void Valid_Countryid( )
      {
         n9CountryId = false;
         /* Using cursor T000A19 */
         pr_default.execute(17, new Object[] {n9CountryId, A9CountryId});
         if ( (pr_default.getStatus(17) == 101) )
         {
            if ( ! ( (0==A9CountryId) ) )
            {
               GX_msglist.addItem("No matching 'Country'.", "ForeignKeyNotFound", 1, "COUNTRYID");
               AnyError = 1;
               GX_FocusControl = edtCountryId_Internalname;
            }
         }
         A10CountryName = T000A19_A10CountryName[0];
         pr_default.close(17);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A10CountryName", StringUtil.RTrim( A10CountryName));
      }

      public void Valid_Categoryid( )
      {
         n12CategoryId = false;
         /* Using cursor T000A20 */
         pr_default.execute(18, new Object[] {n12CategoryId, A12CategoryId});
         if ( (pr_default.getStatus(18) == 101) )
         {
            if ( ! ( (0==A12CategoryId) ) )
            {
               GX_msglist.addItem("No matching 'Category'.", "ForeignKeyNotFound", 1, "CATEGORYID");
               AnyError = 1;
               GX_FocusControl = edtCategoryId_Internalname;
            }
         }
         A13CategoryName = T000A20_A13CategoryName[0];
         pr_default.close(18);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A13CategoryName", StringUtil.RTrim( A13CategoryName));
      }

      public void Valid_Cityid( )
      {
         n9CountryId = false;
         n15CityId = false;
         /* Using cursor T000A21 */
         pr_default.execute(19, new Object[] {n9CountryId, A9CountryId, n15CityId, A15CityId});
         if ( (pr_default.getStatus(19) == 101) )
         {
            if ( ! ( (0==A9CountryId) || (0==A15CityId) ) )
            {
               GX_msglist.addItem("No matching 'City'.", "ForeignKeyNotFound", 1, "CITYID");
               AnyError = 1;
               GX_FocusControl = edtCountryId_Internalname;
            }
         }
         A16CityName = T000A21_A16CityName[0];
         pr_default.close(19);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A16CityName", StringUtil.RTrim( A16CityName));
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","""{"handler":"UserMainFullajax","iparms":[{"postForm":true}]}""");
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true},{"av":"AV9TrnContext","fld":"vTRNCONTEXT","hsh":true}]}""");
         setEventMetadata("AFTER TRN","""{"handler":"E120A2","iparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true},{"av":"AV9TrnContext","fld":"vTRNCONTEXT","hsh":true}]}""");
         setEventMetadata("VALID_ATTRACTIONID","""{"handler":"Valid_Attractionid","iparms":[{"av":"AV9TrnContext","fld":"vTRNCONTEXT","hsh":true},{"av":"A7AttractionId","fld":"ATTRACTIONID","pic":"ZZZ9"},{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true},{"av":"AV16Pgmname","fld":"vPGMNAME"}]""");
         setEventMetadata("VALID_ATTRACTIONID",""","oparms":[{"av":"A8AttractionName","fld":"ATTRACTIONNAME"},{"av":"A9CountryId","fld":"COUNTRYID","pic":"ZZZ9"},{"av":"A12CategoryId","fld":"CATEGORYID","pic":"ZZZ9"},{"av":"A14AttractionFoto","fld":"ATTRACTIONFOTO"},{"av":"A40000AttractionFoto_GXI","fld":"ATTRACTIONFOTO_GXI"},{"av":"A15CityId","fld":"CITYID","pic":"ZZZ9"},{"av":"AV16Pgmname","fld":"vPGMNAME"},{"av":"A10CountryName","fld":"COUNTRYNAME"},{"av":"A16CityName","fld":"CITYNAME"},{"av":"A13CategoryName","fld":"CATEGORYNAME"},{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true},{"av":"Z7AttractionId"},{"av":"Z8AttractionName"},{"av":"Z9CountryId"},{"av":"Z12CategoryId"},{"av":"Z14AttractionFoto"},{"av":"Z40000AttractionFoto_GXI"},{"av":"Z15CityId"},{"av":"ZV16Pgmname"},{"av":"Z10CountryName"},{"av":"Z16CityName"},{"av":"Z13CategoryName"},{"ctrl":"BTN_DELETE","prop":"Enabled"},{"ctrl":"BTN_ENTER","prop":"Enabled"}]}""");
         setEventMetadata("VALID_ATTRACTIONNAME","""{"handler":"Valid_Attractionname","iparms":[{"av":"A8AttractionName","fld":"ATTRACTIONNAME"},{"av":"A7AttractionId","fld":"ATTRACTIONID","pic":"ZZZ9"}]}""");
         setEventMetadata("VALID_COUNTRYID","""{"handler":"Valid_Countryid","iparms":[{"av":"A9CountryId","fld":"COUNTRYID","pic":"ZZZ9"},{"av":"A10CountryName","fld":"COUNTRYNAME"}]""");
         setEventMetadata("VALID_COUNTRYID",""","oparms":[{"av":"A10CountryName","fld":"COUNTRYNAME"}]}""");
         setEventMetadata("VALID_CATEGORYID","""{"handler":"Valid_Categoryid","iparms":[{"av":"A12CategoryId","fld":"CATEGORYID","pic":"ZZZ9"},{"av":"A13CategoryName","fld":"CATEGORYNAME"}]""");
         setEventMetadata("VALID_CATEGORYID",""","oparms":[{"av":"A13CategoryName","fld":"CATEGORYNAME"}]}""");
         setEventMetadata("VALID_CITYID","""{"handler":"Valid_Cityid","iparms":[{"av":"A9CountryId","fld":"COUNTRYID","pic":"ZZZ9"},{"av":"A15CityId","fld":"CITYID","pic":"ZZZ9"},{"av":"A16CityName","fld":"CITYNAME"}]""");
         setEventMetadata("VALID_CITYID",""","oparms":[{"av":"A16CityName","fld":"CITYNAME"}]}""");
         return  ;
      }

      public override void cleanup( )
      {
         CloseCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
      }

      protected override void CloseCursors( )
      {
         pr_default.close(1);
         pr_default.close(17);
         pr_default.close(19);
         pr_default.close(18);
      }

      public override void initialize( )
      {
         sPrefix = "";
         Z8AttractionName = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         GXKey = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Form = new GXWebForm();
         GX_FocusControl = "";
         lblTitle_Jsonclick = "";
         ClassString = "";
         StyleString = "";
         TempTags = "";
         bttBtn_first_Jsonclick = "";
         bttBtn_previous_Jsonclick = "";
         bttBtn_next_Jsonclick = "";
         bttBtn_last_Jsonclick = "";
         bttBtn_select_Jsonclick = "";
         A8AttractionName = "";
         imgprompt_9_gximage = "";
         sImgUrl = "";
         A10CountryName = "";
         imgprompt_12_gximage = "";
         A13CategoryName = "";
         A14AttractionFoto = "";
         A40000AttractionFoto_GXI = "";
         imgprompt_15_gximage = "";
         A16CityName = "";
         bttBtn_enter_Jsonclick = "";
         bttBtn_cancel_Jsonclick = "";
         bttBtn_delete_Jsonclick = "";
         Gx_mode = "";
         AV16Pgmname = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         AV9TrnContext = new GeneXus.Programs.general.ui.SdtTransactionContext(context);
         AV10WebSession = context.GetSession();
         AV14TrnContextAtt = new GeneXus.Programs.general.ui.SdtTransactionContext_Attribute(context);
         Z14AttractionFoto = "";
         Z40000AttractionFoto_GXI = "";
         Z10CountryName = "";
         Z13CategoryName = "";
         Z16CityName = "";
         T000A7_A7AttractionId = new short[1] ;
         T000A7_A8AttractionName = new string[] {""} ;
         T000A7_A10CountryName = new string[] {""} ;
         T000A7_A13CategoryName = new string[] {""} ;
         T000A7_A40000AttractionFoto_GXI = new string[] {""} ;
         T000A7_A16CityName = new string[] {""} ;
         T000A7_A9CountryId = new short[1] ;
         T000A7_n9CountryId = new bool[] {false} ;
         T000A7_A15CityId = new short[1] ;
         T000A7_n15CityId = new bool[] {false} ;
         T000A7_A12CategoryId = new short[1] ;
         T000A7_n12CategoryId = new bool[] {false} ;
         T000A7_A14AttractionFoto = new string[] {""} ;
         T000A8_A8AttractionName = new string[] {""} ;
         T000A4_A10CountryName = new string[] {""} ;
         T000A5_A16CityName = new string[] {""} ;
         T000A6_A13CategoryName = new string[] {""} ;
         T000A9_A10CountryName = new string[] {""} ;
         T000A10_A16CityName = new string[] {""} ;
         T000A11_A13CategoryName = new string[] {""} ;
         T000A12_A7AttractionId = new short[1] ;
         T000A3_A7AttractionId = new short[1] ;
         T000A3_A8AttractionName = new string[] {""} ;
         T000A3_A40000AttractionFoto_GXI = new string[] {""} ;
         T000A3_A9CountryId = new short[1] ;
         T000A3_n9CountryId = new bool[] {false} ;
         T000A3_A15CityId = new short[1] ;
         T000A3_n15CityId = new bool[] {false} ;
         T000A3_A12CategoryId = new short[1] ;
         T000A3_n12CategoryId = new bool[] {false} ;
         T000A3_A14AttractionFoto = new string[] {""} ;
         sMode2 = "";
         T000A13_A7AttractionId = new short[1] ;
         T000A14_A7AttractionId = new short[1] ;
         T000A2_A7AttractionId = new short[1] ;
         T000A2_A8AttractionName = new string[] {""} ;
         T000A2_A40000AttractionFoto_GXI = new string[] {""} ;
         T000A2_A9CountryId = new short[1] ;
         T000A2_n9CountryId = new bool[] {false} ;
         T000A2_A15CityId = new short[1] ;
         T000A2_n15CityId = new bool[] {false} ;
         T000A2_A12CategoryId = new short[1] ;
         T000A2_n12CategoryId = new bool[] {false} ;
         T000A2_A14AttractionFoto = new string[] {""} ;
         T000A15_A7AttractionId = new short[1] ;
         T000A19_A10CountryName = new string[] {""} ;
         T000A20_A13CategoryName = new string[] {""} ;
         T000A21_A16CityName = new string[] {""} ;
         T000A22_A37SuplierId = new short[1] ;
         T000A22_A7AttractionId = new short[1] ;
         T000A23_A7AttractionId = new short[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXCCtlgxBlob = "";
         ZV16Pgmname = "";
         ZZ8AttractionName = "";
         ZZ14AttractionFoto = "";
         ZZ40000AttractionFoto_GXI = "";
         ZZV16Pgmname = "";
         ZZ10CountryName = "";
         ZZ16CityName = "";
         ZZ13CategoryName = "";
         T000A24_A8AttractionName = new string[] {""} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.attractionsinpattern__default(),
            new Object[][] {
                new Object[] {
               T000A2_A7AttractionId, T000A2_A8AttractionName, T000A2_A40000AttractionFoto_GXI, T000A2_A9CountryId, T000A2_n9CountryId, T000A2_A15CityId, T000A2_n15CityId, T000A2_A12CategoryId, T000A2_n12CategoryId, T000A2_A14AttractionFoto
               }
               , new Object[] {
               T000A3_A7AttractionId, T000A3_A8AttractionName, T000A3_A40000AttractionFoto_GXI, T000A3_A9CountryId, T000A3_n9CountryId, T000A3_A15CityId, T000A3_n15CityId, T000A3_A12CategoryId, T000A3_n12CategoryId, T000A3_A14AttractionFoto
               }
               , new Object[] {
               T000A4_A10CountryName
               }
               , new Object[] {
               T000A5_A16CityName
               }
               , new Object[] {
               T000A6_A13CategoryName
               }
               , new Object[] {
               T000A7_A7AttractionId, T000A7_A8AttractionName, T000A7_A10CountryName, T000A7_A13CategoryName, T000A7_A40000AttractionFoto_GXI, T000A7_A16CityName, T000A7_A9CountryId, T000A7_n9CountryId, T000A7_A15CityId, T000A7_n15CityId,
               T000A7_A12CategoryId, T000A7_n12CategoryId, T000A7_A14AttractionFoto
               }
               , new Object[] {
               T000A8_A8AttractionName
               }
               , new Object[] {
               T000A9_A10CountryName
               }
               , new Object[] {
               T000A10_A16CityName
               }
               , new Object[] {
               T000A11_A13CategoryName
               }
               , new Object[] {
               T000A12_A7AttractionId
               }
               , new Object[] {
               T000A13_A7AttractionId
               }
               , new Object[] {
               T000A14_A7AttractionId
               }
               , new Object[] {
               T000A15_A7AttractionId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000A19_A10CountryName
               }
               , new Object[] {
               T000A20_A13CategoryName
               }
               , new Object[] {
               T000A21_A16CityName
               }
               , new Object[] {
               T000A22_A37SuplierId, T000A22_A7AttractionId
               }
               , new Object[] {
               T000A23_A7AttractionId
               }
               , new Object[] {
               T000A24_A8AttractionName
               }
            }
         );
         AV16Pgmname = "AttractionSinPattern";
         AV16Pgmname = "AttractionSinPattern";
      }

      private short Z7AttractionId ;
      private short Z9CountryId ;
      private short Z15CityId ;
      private short Z12CategoryId ;
      private short GxWebError ;
      private short A9CountryId ;
      private short A15CityId ;
      private short A12CategoryId ;
      private short gxcookieaux ;
      private short AnyError ;
      private short IsModified ;
      private short IsConfirmed ;
      private short nKeyPressed ;
      private short A7AttractionId ;
      private short AV11Insert_CountryId ;
      private short AV12Insert_CategoryId ;
      private short AV13Insert_CityId ;
      private short RcdFound2 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private short ZZ7AttractionId ;
      private short ZZ9CountryId ;
      private short ZZ12CategoryId ;
      private short ZZ15CityId ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtAttractionId_Enabled ;
      private int edtAttractionName_Enabled ;
      private int edtCountryId_Enabled ;
      private int imgprompt_9_Visible ;
      private int edtCountryName_Enabled ;
      private int edtCategoryId_Enabled ;
      private int imgprompt_12_Visible ;
      private int edtCategoryName_Enabled ;
      private int imgAttractionFoto_Enabled ;
      private int edtCityId_Enabled ;
      private int imgprompt_15_Visible ;
      private int edtCityName_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int AV17GXV1 ;
      private int idxLst ;
      private string sPrefix ;
      private string Z8AttractionName ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtAttractionId_Internalname ;
      private string divMaintable_Internalname ;
      private string divTitlecontainer_Internalname ;
      private string lblTitle_Internalname ;
      private string lblTitle_Jsonclick ;
      private string ClassString ;
      private string StyleString ;
      private string divFormcontainer_Internalname ;
      private string divToolbarcell_Internalname ;
      private string TempTags ;
      private string bttBtn_first_Internalname ;
      private string bttBtn_first_Jsonclick ;
      private string bttBtn_previous_Internalname ;
      private string bttBtn_previous_Jsonclick ;
      private string bttBtn_next_Internalname ;
      private string bttBtn_next_Jsonclick ;
      private string bttBtn_last_Internalname ;
      private string bttBtn_last_Jsonclick ;
      private string bttBtn_select_Internalname ;
      private string bttBtn_select_Jsonclick ;
      private string edtAttractionId_Jsonclick ;
      private string edtAttractionName_Internalname ;
      private string A8AttractionName ;
      private string edtAttractionName_Jsonclick ;
      private string edtCountryId_Internalname ;
      private string edtCountryId_Jsonclick ;
      private string imgprompt_9_gximage ;
      private string sImgUrl ;
      private string imgprompt_9_Internalname ;
      private string imgprompt_9_Link ;
      private string edtCountryName_Internalname ;
      private string A10CountryName ;
      private string edtCountryName_Jsonclick ;
      private string edtCategoryId_Internalname ;
      private string edtCategoryId_Jsonclick ;
      private string imgprompt_12_gximage ;
      private string imgprompt_12_Internalname ;
      private string imgprompt_12_Link ;
      private string edtCategoryName_Internalname ;
      private string A13CategoryName ;
      private string edtCategoryName_Jsonclick ;
      private string imgAttractionFoto_Internalname ;
      private string edtCityId_Internalname ;
      private string edtCityId_Jsonclick ;
      private string imgprompt_15_gximage ;
      private string imgprompt_15_Internalname ;
      private string imgprompt_15_Link ;
      private string edtCityName_Internalname ;
      private string A16CityName ;
      private string edtCityName_Jsonclick ;
      private string bttBtn_enter_Internalname ;
      private string bttBtn_enter_Caption ;
      private string bttBtn_enter_Jsonclick ;
      private string bttBtn_enter_Tooltiptext ;
      private string bttBtn_cancel_Internalname ;
      private string bttBtn_cancel_Jsonclick ;
      private string bttBtn_delete_Internalname ;
      private string bttBtn_delete_Jsonclick ;
      private string Gx_mode ;
      private string AV16Pgmname ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string Z10CountryName ;
      private string Z13CategoryName ;
      private string Z16CityName ;
      private string sMode2 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXCCtlgxBlob ;
      private string ZV16Pgmname ;
      private string ZZ8AttractionName ;
      private string ZZV16Pgmname ;
      private string ZZ10CountryName ;
      private string ZZ16CityName ;
      private string ZZ13CategoryName ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n9CountryId ;
      private bool n15CityId ;
      private bool n12CategoryId ;
      private bool wbErr ;
      private bool A14AttractionFoto_IsBlob ;
      private bool returnInSub ;
      private string A40000AttractionFoto_GXI ;
      private string Z40000AttractionFoto_GXI ;
      private string ZZ40000AttractionFoto_GXI ;
      private string A14AttractionFoto ;
      private string Z14AttractionFoto ;
      private string ZZ14AttractionFoto ;
      private IGxSession AV10WebSession ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.general.ui.SdtTransactionContext AV9TrnContext ;
      private GeneXus.Programs.general.ui.SdtTransactionContext_Attribute AV14TrnContextAtt ;
      private IDataStoreProvider pr_default ;
      private short[] T000A7_A7AttractionId ;
      private string[] T000A7_A8AttractionName ;
      private string[] T000A7_A10CountryName ;
      private string[] T000A7_A13CategoryName ;
      private string[] T000A7_A40000AttractionFoto_GXI ;
      private string[] T000A7_A16CityName ;
      private short[] T000A7_A9CountryId ;
      private bool[] T000A7_n9CountryId ;
      private short[] T000A7_A15CityId ;
      private bool[] T000A7_n15CityId ;
      private short[] T000A7_A12CategoryId ;
      private bool[] T000A7_n12CategoryId ;
      private string[] T000A7_A14AttractionFoto ;
      private string[] T000A8_A8AttractionName ;
      private string[] T000A4_A10CountryName ;
      private string[] T000A5_A16CityName ;
      private string[] T000A6_A13CategoryName ;
      private string[] T000A9_A10CountryName ;
      private string[] T000A10_A16CityName ;
      private string[] T000A11_A13CategoryName ;
      private short[] T000A12_A7AttractionId ;
      private short[] T000A3_A7AttractionId ;
      private string[] T000A3_A8AttractionName ;
      private string[] T000A3_A40000AttractionFoto_GXI ;
      private short[] T000A3_A9CountryId ;
      private bool[] T000A3_n9CountryId ;
      private short[] T000A3_A15CityId ;
      private bool[] T000A3_n15CityId ;
      private short[] T000A3_A12CategoryId ;
      private bool[] T000A3_n12CategoryId ;
      private string[] T000A3_A14AttractionFoto ;
      private short[] T000A13_A7AttractionId ;
      private short[] T000A14_A7AttractionId ;
      private short[] T000A2_A7AttractionId ;
      private string[] T000A2_A8AttractionName ;
      private string[] T000A2_A40000AttractionFoto_GXI ;
      private short[] T000A2_A9CountryId ;
      private bool[] T000A2_n9CountryId ;
      private short[] T000A2_A15CityId ;
      private bool[] T000A2_n15CityId ;
      private short[] T000A2_A12CategoryId ;
      private bool[] T000A2_n12CategoryId ;
      private string[] T000A2_A14AttractionFoto ;
      private short[] T000A15_A7AttractionId ;
      private string[] T000A19_A10CountryName ;
      private string[] T000A20_A13CategoryName ;
      private string[] T000A21_A16CityName ;
      private short[] T000A22_A37SuplierId ;
      private short[] T000A22_A7AttractionId ;
      private short[] T000A23_A7AttractionId ;
      private string[] T000A24_A8AttractionName ;
   }

   public class attractionsinpattern__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
         ,new ForEachCursor(def[2])
         ,new ForEachCursor(def[3])
         ,new ForEachCursor(def[4])
         ,new ForEachCursor(def[5])
         ,new ForEachCursor(def[6])
         ,new ForEachCursor(def[7])
         ,new ForEachCursor(def[8])
         ,new ForEachCursor(def[9])
         ,new ForEachCursor(def[10])
         ,new ForEachCursor(def[11])
         ,new ForEachCursor(def[12])
         ,new ForEachCursor(def[13])
         ,new UpdateCursor(def[14])
         ,new UpdateCursor(def[15])
         ,new UpdateCursor(def[16])
         ,new ForEachCursor(def[17])
         ,new ForEachCursor(def[18])
         ,new ForEachCursor(def[19])
         ,new ForEachCursor(def[20])
         ,new ForEachCursor(def[21])
         ,new ForEachCursor(def[22])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmT000A2;
          prmT000A2 = new Object[] {
          new ParDef("@AttractionId",GXType.Int16,4,0)
          };
          Object[] prmT000A3;
          prmT000A3 = new Object[] {
          new ParDef("@AttractionId",GXType.Int16,4,0)
          };
          Object[] prmT000A4;
          prmT000A4 = new Object[] {
          new ParDef("@CountryId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT000A5;
          prmT000A5 = new Object[] {
          new ParDef("@CountryId",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("@CityId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT000A6;
          prmT000A6 = new Object[] {
          new ParDef("@CategoryId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT000A7;
          prmT000A7 = new Object[] {
          new ParDef("@AttractionId",GXType.Int16,4,0)
          };
          Object[] prmT000A8;
          prmT000A8 = new Object[] {
          new ParDef("@AttractionName",GXType.NChar,50,0) ,
          new ParDef("@AttractionId",GXType.Int16,4,0)
          };
          Object[] prmT000A9;
          prmT000A9 = new Object[] {
          new ParDef("@CountryId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT000A10;
          prmT000A10 = new Object[] {
          new ParDef("@CountryId",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("@CityId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT000A11;
          prmT000A11 = new Object[] {
          new ParDef("@CategoryId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT000A12;
          prmT000A12 = new Object[] {
          new ParDef("@AttractionId",GXType.Int16,4,0)
          };
          Object[] prmT000A13;
          prmT000A13 = new Object[] {
          new ParDef("@AttractionId",GXType.Int16,4,0)
          };
          Object[] prmT000A14;
          prmT000A14 = new Object[] {
          new ParDef("@AttractionId",GXType.Int16,4,0)
          };
          Object[] prmT000A15;
          prmT000A15 = new Object[] {
          new ParDef("@AttractionName",GXType.NChar,50,0) ,
          new ParDef("@AttractionFoto",GXType.Blob,1024,0){InDB=false} ,
          new ParDef("@AttractionFoto_GXI",GXType.VarChar,2048,0){AddAtt=true, ImgIdx=1, Tbl="Attraction", Fld="AttractionFoto"} ,
          new ParDef("@CountryId",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("@CityId",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("@CategoryId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT000A16;
          prmT000A16 = new Object[] {
          new ParDef("@AttractionName",GXType.NChar,50,0) ,
          new ParDef("@CountryId",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("@CityId",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("@CategoryId",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("@AttractionId",GXType.Int16,4,0)
          };
          Object[] prmT000A17;
          prmT000A17 = new Object[] {
          new ParDef("@AttractionFoto",GXType.Blob,1024,0){InDB=false} ,
          new ParDef("@AttractionFoto_GXI",GXType.VarChar,2048,0){AddAtt=true, ImgIdx=0, Tbl="Attraction", Fld="AttractionFoto"} ,
          new ParDef("@AttractionId",GXType.Int16,4,0)
          };
          Object[] prmT000A18;
          prmT000A18 = new Object[] {
          new ParDef("@AttractionId",GXType.Int16,4,0)
          };
          Object[] prmT000A19;
          prmT000A19 = new Object[] {
          new ParDef("@CountryId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT000A20;
          prmT000A20 = new Object[] {
          new ParDef("@CategoryId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT000A21;
          prmT000A21 = new Object[] {
          new ParDef("@CountryId",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("@CityId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT000A22;
          prmT000A22 = new Object[] {
          new ParDef("@AttractionId",GXType.Int16,4,0)
          };
          Object[] prmT000A23;
          prmT000A23 = new Object[] {
          };
          Object[] prmT000A24;
          prmT000A24 = new Object[] {
          new ParDef("@AttractionName",GXType.NChar,50,0) ,
          new ParDef("@AttractionId",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("T000A2", "SELECT [AttractionId], [AttractionName], [AttractionFoto_GXI], [CountryId], [CityId], [CategoryId], [AttractionFoto] FROM [Attraction] WITH (UPDLOCK) WHERE [AttractionId] = @AttractionId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000A2,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000A3", "SELECT [AttractionId], [AttractionName], [AttractionFoto_GXI], [CountryId], [CityId], [CategoryId], [AttractionFoto] FROM [Attraction] WHERE [AttractionId] = @AttractionId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000A3,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000A4", "SELECT [CountryName] FROM [Country] WHERE [CountryId] = @CountryId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000A4,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000A5", "SELECT [CityName] FROM [CountryCity] WHERE [CountryId] = @CountryId AND [CityId] = @CityId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000A5,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000A6", "SELECT [CategoryName] FROM [Category] WHERE [CategoryId] = @CategoryId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000A6,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000A7", "SELECT TM1.[AttractionId], TM1.[AttractionName], T2.[CountryName], T3.[CategoryName], TM1.[AttractionFoto_GXI], T4.[CityName], TM1.[CountryId], TM1.[CityId], TM1.[CategoryId], TM1.[AttractionFoto] FROM ((([Attraction] TM1 LEFT JOIN [Country] T2 ON T2.[CountryId] = TM1.[CountryId]) LEFT JOIN [Category] T3 ON T3.[CategoryId] = TM1.[CategoryId]) LEFT JOIN [CountryCity] T4 ON T4.[CountryId] = TM1.[CountryId] AND T4.[CityId] = TM1.[CityId]) WHERE TM1.[AttractionId] = @AttractionId ORDER BY TM1.[AttractionId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000A7,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000A8", "SELECT [AttractionName] FROM [Attraction] WHERE ([AttractionName] = @AttractionName) AND (Not ( [AttractionId] = @AttractionId)) ",true, GxErrorMask.GX_NOMASK, false, this,prmT000A8,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000A9", "SELECT [CountryName] FROM [Country] WHERE [CountryId] = @CountryId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000A9,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000A10", "SELECT [CityName] FROM [CountryCity] WHERE [CountryId] = @CountryId AND [CityId] = @CityId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000A10,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000A11", "SELECT [CategoryName] FROM [Category] WHERE [CategoryId] = @CategoryId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000A11,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000A12", "SELECT [AttractionId] FROM [Attraction] WHERE [AttractionId] = @AttractionId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000A12,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000A13", "SELECT TOP 1 [AttractionId] FROM [Attraction] WHERE ( [AttractionId] > @AttractionId) ORDER BY [AttractionId]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000A13,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000A14", "SELECT TOP 1 [AttractionId] FROM [Attraction] WHERE ( [AttractionId] < @AttractionId) ORDER BY [AttractionId] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000A14,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000A15", "INSERT INTO [Attraction]([AttractionName], [AttractionFoto], [AttractionFoto_GXI], [CountryId], [CityId], [CategoryId]) VALUES(@AttractionName, @AttractionFoto, @AttractionFoto_GXI, @CountryId, @CityId, @CategoryId); SELECT SCOPE_IDENTITY()",true, GxErrorMask.GX_NOMASK, false, this,prmT000A15,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000A16", "UPDATE [Attraction] SET [AttractionName]=@AttractionName, [CountryId]=@CountryId, [CityId]=@CityId, [CategoryId]=@CategoryId  WHERE [AttractionId] = @AttractionId", GxErrorMask.GX_NOMASK,prmT000A16)
             ,new CursorDef("T000A17", "UPDATE [Attraction] SET [AttractionFoto]=@AttractionFoto, [AttractionFoto_GXI]=@AttractionFoto_GXI  WHERE [AttractionId] = @AttractionId", GxErrorMask.GX_NOMASK,prmT000A17)
             ,new CursorDef("T000A18", "DELETE FROM [Attraction]  WHERE [AttractionId] = @AttractionId", GxErrorMask.GX_NOMASK,prmT000A18)
             ,new CursorDef("T000A19", "SELECT [CountryName] FROM [Country] WHERE [CountryId] = @CountryId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000A19,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000A20", "SELECT [CategoryName] FROM [Category] WHERE [CategoryId] = @CategoryId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000A20,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000A21", "SELECT [CityName] FROM [CountryCity] WHERE [CountryId] = @CountryId AND [CityId] = @CityId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000A21,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000A22", "SELECT TOP 1 [SuplierId], [AttractionId] FROM [SuplierAttraction] WHERE [AttractionId] = @AttractionId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000A22,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000A23", "SELECT [AttractionId] FROM [Attraction] ORDER BY [AttractionId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000A23,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000A24", "SELECT [AttractionName] FROM [Attraction] WHERE ([AttractionName] = @AttractionName) AND (Not ( [AttractionId] = @AttractionId)) ",true, GxErrorMask.GX_NOMASK, false, this,prmT000A24,1, GxCacheFrequency.OFF ,true,false )
          };
       }
    }

    public void getResults( int cursor ,
                            IFieldGetter rslt ,
                            Object[] buf )
    {
       switch ( cursor )
       {
             case 0 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 50);
                ((string[]) buf[2])[0] = rslt.getMultimediaUri(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((bool[]) buf[4])[0] = rslt.wasNull(4);
                ((short[]) buf[5])[0] = rslt.getShort(5);
                ((bool[]) buf[6])[0] = rslt.wasNull(5);
                ((short[]) buf[7])[0] = rslt.getShort(6);
                ((bool[]) buf[8])[0] = rslt.wasNull(6);
                ((string[]) buf[9])[0] = rslt.getMultimediaFile(7, rslt.getVarchar(3));
                return;
             case 1 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 50);
                ((string[]) buf[2])[0] = rslt.getMultimediaUri(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((bool[]) buf[4])[0] = rslt.wasNull(4);
                ((short[]) buf[5])[0] = rslt.getShort(5);
                ((bool[]) buf[6])[0] = rslt.wasNull(5);
                ((short[]) buf[7])[0] = rslt.getShort(6);
                ((bool[]) buf[8])[0] = rslt.wasNull(6);
                ((string[]) buf[9])[0] = rslt.getMultimediaFile(7, rslt.getVarchar(3));
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getString(1, 50);
                return;
             case 3 :
                ((string[]) buf[0])[0] = rslt.getString(1, 50);
                return;
             case 4 :
                ((string[]) buf[0])[0] = rslt.getString(1, 50);
                return;
             case 5 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 50);
                ((string[]) buf[2])[0] = rslt.getString(3, 50);
                ((string[]) buf[3])[0] = rslt.getString(4, 50);
                ((string[]) buf[4])[0] = rslt.getMultimediaUri(5);
                ((string[]) buf[5])[0] = rslt.getString(6, 50);
                ((short[]) buf[6])[0] = rslt.getShort(7);
                ((bool[]) buf[7])[0] = rslt.wasNull(7);
                ((short[]) buf[8])[0] = rslt.getShort(8);
                ((bool[]) buf[9])[0] = rslt.wasNull(8);
                ((short[]) buf[10])[0] = rslt.getShort(9);
                ((bool[]) buf[11])[0] = rslt.wasNull(9);
                ((string[]) buf[12])[0] = rslt.getMultimediaFile(10, rslt.getVarchar(5));
                return;
             case 6 :
                ((string[]) buf[0])[0] = rslt.getString(1, 50);
                return;
             case 7 :
                ((string[]) buf[0])[0] = rslt.getString(1, 50);
                return;
             case 8 :
                ((string[]) buf[0])[0] = rslt.getString(1, 50);
                return;
             case 9 :
                ((string[]) buf[0])[0] = rslt.getString(1, 50);
                return;
             case 10 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 11 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 12 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 13 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 17 :
                ((string[]) buf[0])[0] = rslt.getString(1, 50);
                return;
             case 18 :
                ((string[]) buf[0])[0] = rslt.getString(1, 50);
                return;
             case 19 :
                ((string[]) buf[0])[0] = rslt.getString(1, 50);
                return;
             case 20 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                return;
             case 21 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 22 :
                ((string[]) buf[0])[0] = rslt.getString(1, 50);
                return;
       }
    }

 }

}
