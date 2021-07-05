#pragma checksum "D:\Github\IT Support Helpdesk\Web\Views\Panel\Profile.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "03a5fbe995e5cecbfb36cedbae683318f1116dc3"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Panel_Profile), @"mvc.1.0.view", @"/Views/Panel/Profile.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "D:\Github\IT Support Helpdesk\Web\Views\_ViewImports.cshtml"
using Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Github\IT Support Helpdesk\Web\Views\_ViewImports.cshtml"
using Web.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"03a5fbe995e5cecbfb36cedbae683318f1116dc3", @"/Views/Panel/Profile.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"74b0619e1a302f0598271da1847e697c39d57b88", @"/Views/_ViewImports.cshtml")]
    public class Views_Panel_Profile : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("profile-user-img img-fluid img-circle"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/lib/adminlte/img/user4-128x128.jpg"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString("User profile picture"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("form-horizontal"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("formprofile"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", "~/js/Profile.js", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.ScriptTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "D:\Github\IT Support Helpdesk\Web\Views\Panel\Profile.cshtml"
  
    ViewData["Title"] = "List Categories";
    Layout = "_PanelLayout";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<!-- Content Wrapper. Contains page content -->
<div class=""content-wrapper"">
    <!-- Content Header (Page header) -->
    <section class=""content-header"">
        <div class=""container-fluid"">
            <div class=""row mb-2"">
                <div class=""col-sm-6"">
                    <h1>Profile</h1>
                </div>
                <div class=""col-sm-6"">
                    <ol class=""breadcrumb float-sm-right"">
                        <li class=""breadcrumb-item""><a href=""#"">Home</a></li>
                        <li class=""breadcrumb-item active"">User Profile</li>
                    </ol>
                </div>
            </div>
        </div><!-- /.container-fluid -->
    </section>

    <!-- Main content -->
    <section class=""content"">
        <div class=""container-fluid"">
            <div class=""row"">
                <!-- /.col -->
                <div class=""col-md-12"">
                    <div class=""card"">
                        <div class=""card-header p-2"">
  ");
            WriteLiteral(@"                          <ul class=""nav nav-pills"">
                                <li class=""nav-item""><a class=""nav-link active"" href=""#profile"" data-toggle=""tab"">Profile</a></li>
                                <li class=""nav-item""><a class=""nav-link"" href=""#settings"" data-toggle=""tab""");
            BeginWriteAttribute("onclick", " onclick=\"", 1398, "\"", 1437, 3);
            WriteAttributeValue("", 1408, "getProfile(\'", 1408, 12, true);
#nullable restore
#line 34 "D:\Github\IT Support Helpdesk\Web\Views\Panel\Profile.cshtml"
WriteAttributeValue("", 1420, ViewBag.UserId, 1420, 15, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1435, "\')", 1435, 2, true);
            EndWriteAttribute();
            WriteLiteral(@">Settings</a></li>
                                <li class=""nav-item""><a class=""nav-link"" href=""#avatar"" data-toggle=""tab"">Avatar</a></li>
                            </ul>
                        </div><!-- /.card-header -->
                        <div class=""card-body"">
                            <div class=""tab-content"">
                                <div class=""active tab-pane"" id=""profile"">
                                    <div class=""card-body box-profile"">
                                        <div class=""text-center"">
                                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "03a5fbe995e5cecbfb36cedbae683318f1116dc38285", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                                        </div>\r\n\r\n                                        <h3 class=\"profile-username text-center\">");
#nullable restore
#line 48 "D:\Github\IT Support Helpdesk\Web\Views\Panel\Profile.cshtml"
                                                                            Write(ViewBag.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\r\n\r\n                                        <p class=\"text-muted text-center\">");
#nullable restore
#line 50 "D:\Github\IT Support Helpdesk\Web\Views\Panel\Profile.cshtml"
                                                                     Write(ViewBag.Role);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                                        <p class=\"text-muted text-center\">");
#nullable restore
#line 51 "D:\Github\IT Support Helpdesk\Web\Views\Panel\Profile.cshtml"
                                                                     Write(ViewBag.Email);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</p>
                                    </div>
                                    <!--<div class=""card card-primary"">
                                    <div class=""card-header"">
                                        <h3 class=""card-title"">About Me</h3>
                                    </div>-->
                                    <!-- /.card-header -->
                                    <!--<div class=""card-body"">
                                        <strong><i class=""fas fa-envelope mr-1""></i> Email</strong>

                                        <p class=""text-muted"">");
#nullable restore
#line 61 "D:\Github\IT Support Helpdesk\Web\Views\Panel\Profile.cshtml"
                                                         Write(ViewBag.Email);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</p>

                                        <hr>

                                        <strong><i class=""fas fa-map-marker-alt mr-1""></i> Address</strong>

                                        <p class=""text-muted"" id=""Address""></p>

                                        <hr>

                                        <strong><i class=""fas fa-calendar mr-1""></i> Birthdate</strong>

                                        <p class=""text-muted"" id=""BirthDate""></p>

                                        <hr>

                                        <strong><i class=""fas fa-phone mr-1""></i> Phone</strong>

                                        <p class=""text-muted"" id=""Phone""></p>

                                    </div>-->
                                    <!-- /.card-body -->
                                    <!--</div>-->

                                </div>
                                <!-- /.tab-pane -->

                                <div class=""tab-pane");
            WriteLiteral("\" id=\"settings\">\r\n                                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "03a5fbe995e5cecbfb36cedbae683318f1116dc312593", async() => {
                WriteLiteral(@"
                                        <div class=""form-row"">
                                            <div class=""col-md-6 mb-3"">
                                                <input type=""text"" hidden class=""form-control"" id=""Id"" placeholder=""Id"">
                                                <label for=""inputCreateName"">Name</label>
                                                <input type=""text"" class=""form-control"" id=""Name"" placeholder=""Name"" required>
                                                <div class=""invalid-feedback"">
                                                    Please enter right string format.
                                                </div>
                                            </div>
                                            <div class=""col-md-6 mb-3"">
                                                <label for=""inputCreateEmail"">Email</label>
                                                <input type=""email"" class=""form-control"" id=""Email"" pla");
                WriteLiteral(@"ceholder=""Email"" required>
                                                <div class=""invalid-feedback"">
                                                    Please enter right email format.
                                                </div>
                                            </div>
                                        </div>
                                        <div class=""form-row"">
                                            <div class=""col-md-6 mb-3"">
                                                <label for=""inputCreatePassword"">Password</label>
                                                <input type=""password"" class=""form-control"" id=""Password"" placeholder=""Password"" required>
                                                <div class=""invalid-feedback"">
                                                    Please enter right string format.
                                                </div>
                                            </div>
                       ");
                WriteLiteral(@"                     <div class=""col-md-6 mb-3"">
                                                <label for=""inputCreateBirthDate"">Birth Date</label>
                                                <input type=""date"" class=""form-control"" id=""BirthDate"" placeholder=""BirthDate"" required>
                                                <div class=""invalid-feedback"">
                                                    Please enter right date format.
                                                </div>
                                            </div>
                                        </div>
                                        <div class=""form-row"">
                                            <div class=""col-md-6 mb-3"">
                                                <label for=""inputCreatePhone"">Phone</label>
                                                <input type=""text"" class=""form-control"" id=""Phone"" placeholder=""Phone"" required>
                                                <div ");
                WriteLiteral(@"class=""invalid-feedback"">
                                                    Please enter right phone format.
                                                </div>
                                            </div>
                                            <div class=""col-md-6 mb-3"">
                                                <input type=""text"" hidden class=""form-control"" id=""Role"" placeholder=""Role"" required>
                                                <label for=""inputCreateAddress"">Address</label>
                                                <input type=""text"" class=""form-control"" id=""Address"" placeholder=""Address"" required>
                                                <div class=""invalid-feedback"">
                                                    Please enter right address format.
                                                </div>
                                            </div>
                                        </div>
                                        ");
                WriteLiteral(@"<div class=""form-row"">
                                            <div class=""col-md-6 mb-3"">
                                                <label for=""inputCreateDepartment"">Department</label>
                                                <input type=""text"" class=""form-control"" id=""Department"" placeholder=""Department"" required>
                                                <div class=""invalid-feedback"">
                                                    Please enter right string format.
                                                </div>
                                            </div>
                                            <div class=""col-md-6 mb-3"">
                                                <label for=""inputCreateCompany"">Company</label>
                                                <input type=""text"" class=""form-control"" id=""Company"" placeholder=""Company"" required>
                                                <div class=""invalid-feedback"">
                         ");
                WriteLiteral(@"                           Please enter right string format.
                                                </div>
                                            </div>
                                        </div>
                                        <div class=""form-group row"">
                                            <div class=""col-sm-10"">
                                                <button type=""submit"" class=""btn btn-danger"" onclick=""editProfile()"">Submit</button>
                                            </div>
                                        </div>
                                    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                                </div>
                                <!-- /.tab-pane -->
                                <div class=""tab-pane"" id=""avatar"">
                                    <div class=""card-body box-profile"">
                                        <div class=""text-center"">
                                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "03a5fbe995e5cecbfb36cedbae683318f1116dc320413", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                                        </div>\r\n\r\n                                        <h3 class=\"profile-username text-center\">");
#nullable restore
#line 172 "D:\Github\IT Support Helpdesk\Web\Views\Panel\Profile.cshtml"
                                                                            Write(ViewBag.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\r\n\r\n                                        <p class=\"text-muted text-center\">");
#nullable restore
#line 174 "D:\Github\IT Support Helpdesk\Web\Views\Panel\Profile.cshtml"
                                                                     Write(ViewBag.Role);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                                        <p class=\"text-muted text-center\">");
#nullable restore
#line 175 "D:\Github\IT Support Helpdesk\Web\Views\Panel\Profile.cshtml"
                                                                     Write(ViewBag.Email);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</p>
                                    </div>
                                </div>
                                <!-- /.tab-pane -->
                            </div>
                            <!-- /.tab-content -->
                        </div><!-- /.card-body -->
                    </div>
                    <!-- /.card -->
                </div>
                <!-- /.col -->
            </div>
            <!-- /.row -->
        </div><!-- /.container-fluid -->
    </section>
    <!-- /.content -->
</div>
<!-- /.content-wrapper -->
");
            DefineSection("scripts", async() => {
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "03a5fbe995e5cecbfb36cedbae683318f1116dc323393", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.ScriptTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper.Src = (string)__tagHelperAttribute_5.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
#nullable restore
#line 194 "D:\Github\IT Support Helpdesk\Web\Views\Panel\Profile.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper.AppendVersion = true;

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-append-version", __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper.AppendVersion, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n");
            }
            );
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
