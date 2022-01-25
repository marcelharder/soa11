using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace api.Migrations
{
    public partial class IdentityAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "AspNetUsers");

            migrationBuilder.AlterColumn<string>(
                name: "PasswordHash",
                table: "AspNetUsers",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(byte[]),
                oldType: "BLOB",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AccessFailedCount",
                table: "AspNetUsers",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "AspNetUsers",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "AspNetUsers",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ConcurrencyStamp",
                table: "AspNetUsers",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "AspNetUsers",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "AspNetUsers",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfBirth",
                table: "AspNetUsers",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "AspNetUsers",
                type: "TEXT",
                maxLength: 256,
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "EmailConfirmed",
                table: "AspNetUsers",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "AspNetUsers",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IBAN",
                table: "AspNetUsers",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Interests",
                table: "AspNetUsers",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Introduction",
                table: "AspNetUsers",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "KnownAs",
                table: "AspNetUsers",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastActive",
                table: "AspNetUsers",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "LockoutEnabled",
                table: "AspNetUsers",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "LockoutEnd",
                table: "AspNetUsers",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LookingFor",
                table: "AspNetUsers",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Mobile",
                table: "AspNetUsers",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NormalizedEmail",
                table: "AspNetUsers",
                type: "TEXT",
                maxLength: 256,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NormalizedUserName",
                table: "AspNetUsers",
                type: "TEXT",
                maxLength: 256,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "AspNetUsers",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "PhoneNumberConfirmed",
                table: "AspNetUsers",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "PhotoUrl",
                table: "AspNetUsers",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SecurityStamp",
                table: "AspNetUsers",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "TwoFactorEnabled",
                table: "AspNetUsers",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "active",
                table: "AspNetUsers",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "hospital_id",
                table: "AspNetUsers",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "ltk",
                table: "AspNetUsers",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "worked_in",
                table: "AspNetUsers",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetUsers",
                table: "AspNetUsers",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "AorticSurgeries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    procedure_id = table.Column<int>(type: "INTEGER", nullable: false),
                    aneurysm = table.Column<bool>(type: "INTEGER", nullable: false),
                    aneurysm_type = table.Column<string>(type: "TEXT", nullable: true),
                    dissection = table.Column<bool>(type: "INTEGER", nullable: false),
                    dissection_onset = table.Column<string>(type: "TEXT", nullable: true),
                    dissection_type = table.Column<string>(type: "TEXT", nullable: true),
                    coarctation = table.Column<bool>(type: "INTEGER", nullable: false),
                    other_congenital = table.Column<bool>(type: "INTEGER", nullable: false),
                    pathology = table.Column<string>(type: "TEXT", nullable: true),
                    indication = table.Column<string>(type: "TEXT", nullable: true),
                    operative_technique = table.Column<string>(type: "TEXT", nullable: true),
                    range = table.Column<string>(type: "TEXT", nullable: true),
                    stent_graft_technique = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AorticSurgeries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "TEXT", nullable: false),
                    ProviderKey = table.Column<string>(type: "TEXT", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "TEXT", nullable: true),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "INTEGER", nullable: false),
                    LoginProvider = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Value = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CABGS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PROCEDURE_ID = table.Column<int>(type: "INTEGER", nullable: false),
                    PATIENT_ID = table.Column<int>(type: "INTEGER", nullable: true),
                    CAB = table.Column<string>(type: "TEXT", nullable: true),
                    UNPLANNED_CAB = table.Column<string>(type: "TEXT", nullable: true),
                    B1_SITE = table.Column<string>(type: "TEXT", nullable: true),
                    B1_TYPE_DA = table.Column<string>(type: "TEXT", nullable: true),
                    B1_LOCPROC = table.Column<string>(type: "TEXT", nullable: true),
                    B1_CONDUIT = table.Column<string>(type: "TEXT", nullable: true),
                    B1_SITEPA = table.Column<string>(type: "TEXT", nullable: true),
                    B1_DONOR = table.Column<string>(type: "TEXT", nullable: true),
                    B2_SITE = table.Column<string>(type: "TEXT", nullable: true),
                    B2_TYPE_DA = table.Column<string>(type: "TEXT", nullable: true),
                    B2_LOCPROC = table.Column<string>(type: "TEXT", nullable: true),
                    B2_CONDUIT = table.Column<string>(type: "TEXT", nullable: true),
                    B2_SITEPA = table.Column<string>(type: "TEXT", nullable: true),
                    B2_DONOR = table.Column<string>(type: "TEXT", nullable: true),
                    B3_SITE = table.Column<string>(type: "TEXT", nullable: true),
                    B3_TYPE_DA = table.Column<string>(type: "TEXT", nullable: true),
                    B3_LOCPROC = table.Column<string>(type: "TEXT", nullable: true),
                    B3_CONDUIT = table.Column<string>(type: "TEXT", nullable: true),
                    B3_SITEPA = table.Column<string>(type: "TEXT", nullable: true),
                    B3_DONOR = table.Column<string>(type: "TEXT", nullable: true),
                    B4_SITE = table.Column<string>(type: "TEXT", nullable: true),
                    B4_TYPE_DA = table.Column<string>(type: "TEXT", nullable: true),
                    B4_LOCPROC = table.Column<string>(type: "TEXT", nullable: true),
                    B4_CONDUIT = table.Column<string>(type: "TEXT", nullable: true),
                    B4_SITEPA = table.Column<string>(type: "TEXT", nullable: true),
                    B4_DONOR = table.Column<string>(type: "TEXT", nullable: true),
                    B5_SITE = table.Column<string>(type: "TEXT", nullable: true),
                    B5_TYPE_DA = table.Column<string>(type: "TEXT", nullable: true),
                    B5_LOCPROC = table.Column<string>(type: "TEXT", nullable: true),
                    B5_CONDUIT = table.Column<string>(type: "TEXT", nullable: true),
                    B5_SITEPA = table.Column<string>(type: "TEXT", nullable: true),
                    B5_DONOR = table.Column<string>(type: "TEXT", nullable: true),
                    B6_SITE = table.Column<string>(type: "TEXT", nullable: true),
                    B6_TYPE_DA = table.Column<string>(type: "TEXT", nullable: true),
                    B6_LOCPROC = table.Column<string>(type: "TEXT", nullable: true),
                    B6_CONDUIT = table.Column<string>(type: "TEXT", nullable: true),
                    B6_SITEPA = table.Column<string>(type: "TEXT", nullable: true),
                    B6_DONOR = table.Column<string>(type: "TEXT", nullable: true),
                    Q01 = table.Column<string>(type: "TEXT", nullable: true),
                    Q02 = table.Column<string>(type: "TEXT", nullable: true),
                    Q03 = table.Column<string>(type: "TEXT", nullable: true),
                    Q04 = table.Column<string>(type: "TEXT", nullable: true),
                    Q05 = table.Column<string>(type: "TEXT", nullable: true),
                    Q06 = table.Column<string>(type: "TEXT", nullable: true),
                    ANGLE01 = table.Column<string>(type: "TEXT", nullable: true),
                    ANGLE02 = table.Column<string>(type: "TEXT", nullable: true),
                    ANGLE03 = table.Column<string>(type: "TEXT", nullable: true),
                    ANGLE04 = table.Column<string>(type: "TEXT", nullable: true),
                    ANGLE05 = table.Column<string>(type: "TEXT", nullable: true),
                    ANGLE06 = table.Column<string>(type: "TEXT", nullable: true),
                    DIAM01 = table.Column<string>(type: "TEXT", nullable: true),
                    DIAM02 = table.Column<string>(type: "TEXT", nullable: true),
                    DIAM03 = table.Column<string>(type: "TEXT", nullable: true),
                    DIAM04 = table.Column<string>(type: "TEXT", nullable: true),
                    DIAM05 = table.Column<string>(type: "TEXT", nullable: true),
                    DIAM06 = table.Column<string>(type: "TEXT", nullable: true),
                    course = table.Column<string>(type: "TEXT", nullable: true),
                    leg_harvest_location = table.Column<string>(type: "TEXT", nullable: true),
                    radial_harvest_location = table.Column<string>(type: "TEXT", nullable: true),
                    leg_harvest_technique = table.Column<string>(type: "TEXT", nullable: true),
                    radial_harvest_technique = table.Column<string>(type: "TEXT", nullable: true),
                    art01 = table.Column<string>(type: "TEXT", nullable: true),
                    art02 = table.Column<string>(type: "TEXT", nullable: true),
                    art03 = table.Column<string>(type: "TEXT", nullable: true),
                    art04 = table.Column<string>(type: "TEXT", nullable: true),
                    art05 = table.Column<string>(type: "TEXT", nullable: true),
                    art06 = table.Column<string>(type: "TEXT", nullable: true),
                    tachtig_switch = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CABGS", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CourseId = table.Column<int>(type: "INTEGER", nullable: false),
                    active = table.Column<string>(type: "TEXT", nullable: true),
                    level = table.Column<int>(type: "INTEGER", nullable: false),
                    description = table.Column<string>(type: "TEXT", nullable: true),
                    title = table.Column<string>(type: "TEXT", nullable: true),
                    diploma = table.Column<string>(type: "TEXT", nullable: true),
                    location = table.Column<string>(type: "TEXT", nullable: true),
                    courseDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    endDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    price = table.Column<float>(type: "REAL", nullable: false),
                    userId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Courses_AspNetUsers_userId",
                        column: x => x.userId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CPBS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PROCEDURE_ID = table.Column<int>(type: "INTEGER", nullable: false),
                    CROSS_CLAMP_TIME = table.Column<int>(type: "INTEGER", nullable: false),
                    PERFUSION_TIME = table.Column<int>(type: "INTEGER", nullable: false),
                    LOWEST_CORE_TEMP = table.Column<int>(type: "INTEGER", nullable: true),
                    CARDIOPLEGIA = table.Column<string>(type: "TEXT", nullable: true),
                    CARDIOPLEGIA_TYPE = table.Column<string>(type: "TEXT", nullable: true),
                    INFUSION_MODE_ANTE = table.Column<string>(type: "TEXT", nullable: true),
                    INFUSION_MODE_RETRO = table.Column<int>(type: "INTEGER", nullable: true),
                    INFUSION_DOSE_INT = table.Column<int>(type: "INTEGER", nullable: true),
                    INFUSION_DOSE_CONT = table.Column<int>(type: "INTEGER", nullable: true),
                    CARDIOPLEGIA_TEMP_WARM = table.Column<int>(type: "INTEGER", nullable: true),
                    CARDIOPLEGIA_TEMP_COLD = table.Column<int>(type: "INTEGER", nullable: true),
                    IABP = table.Column<string>(type: "TEXT", nullable: true),
                    IABP_OPTIONS = table.Column<string>(type: "TEXT", nullable: true),
                    IABP_IND = table.Column<string>(type: "TEXT", nullable: true),
                    PACING_HARV = table.Column<int>(type: "INTEGER", nullable: true),
                    PACING_ATRIAL = table.Column<int>(type: "INTEGER", nullable: true),
                    PACING_VENTRICULAR = table.Column<int>(type: "INTEGER", nullable: true),
                    CARDIOVERSION = table.Column<int>(type: "INTEGER", nullable: true),
                    VAD = table.Column<string>(type: "TEXT", nullable: true),
                    LVAD = table.Column<int>(type: "INTEGER", nullable: true),
                    RVAD = table.Column<int>(type: "INTEGER", nullable: true),
                    BVAD = table.Column<string>(type: "TEXT", nullable: true),
                    TAH = table.Column<string>(type: "TEXT", nullable: true),
                    INOTROPES = table.Column<int>(type: "INTEGER", nullable: true),
                    Antiarrhythmics = table.Column<int>(type: "INTEGER", nullable: true),
                    SKIN_INCISION_START_TIME = table.Column<int>(type: "INTEGER", nullable: true),
                    SKIN_INCISION_STOP_TIME = table.Column<int>(type: "INTEGER", nullable: true),
                    opcab_attempt = table.Column<string>(type: "TEXT", nullable: true),
                    cpb_used = table.Column<string>(type: "TEXT", nullable: true),
                    a1 = table.Column<string>(type: "TEXT", nullable: true),
                    a2 = table.Column<string>(type: "TEXT", nullable: true),
                    a3 = table.Column<string>(type: "TEXT", nullable: true),
                    a4 = table.Column<string>(type: "TEXT", nullable: true),
                    v1 = table.Column<string>(type: "TEXT", nullable: true),
                    v2 = table.Column<string>(type: "TEXT", nullable: true),
                    v3 = table.Column<string>(type: "TEXT", nullable: true),
                    v4 = table.Column<string>(type: "TEXT", nullable: true),
                    aoOCCL = table.Column<string>(type: "TEXT", nullable: true),
                    long_isch = table.Column<int>(type: "INTEGER", nullable: true),
                    cardiopl_timing = table.Column<string>(type: "TEXT", nullable: true),
                    cardiopl_temp = table.Column<string>(type: "TEXT", nullable: true),
                    cns_protect = table.Column<string>(type: "TEXT", nullable: true),
                    cns_time_1 = table.Column<int>(type: "INTEGER", nullable: true),
                    cns_time_2 = table.Column<int>(type: "INTEGER", nullable: true),
                    cns_time_3 = table.Column<int>(type: "INTEGER", nullable: true),
                    deep_hypo = table.Column<string>(type: "TEXT", nullable: true),
                    deep_hypo_rcp = table.Column<string>(type: "TEXT", nullable: true),
                    acp_circ = table.Column<string>(type: "TEXT", nullable: true),
                    other_cns_protect = table.Column<string>(type: "TEXT", nullable: true),
                    nonCMProtect = table.Column<string>(type: "TEXT", nullable: true),
                    nonCMProtect_type = table.Column<short>(type: "INTEGER", nullable: true),
                    IABP_DATE = table.Column<DateTime>(type: "TEXT", nullable: true),
                    myoplasty = table.Column<string>(type: "TEXT", nullable: true),
                    cpb_start_hr = table.Column<int>(type: "INTEGER", nullable: true),
                    cpb_start_min = table.Column<int>(type: "INTEGER", nullable: true),
                    cpb_stop_hr = table.Column<int>(type: "INTEGER", nullable: true),
                    cpb_stop_min = table.Column<int>(type: "INTEGER", nullable: true),
                    clamp_start_hr = table.Column<int>(type: "INTEGER", nullable: true),
                    clamp_start_min = table.Column<int>(type: "INTEGER", nullable: true),
                    clamp_stop_hr = table.Column<int>(type: "INTEGER", nullable: true),
                    clamp_stop_min = table.Column<int>(type: "INTEGER", nullable: true),
                    other_cardiac_support = table.Column<string>(type: "TEXT", nullable: true),
                    cardiac_support = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CPBS", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    name = table.Column<string>(type: "TEXT", nullable: true),
                    image = table.Column<string>(type: "TEXT", nullable: true),
                    profession = table.Column<string>(type: "TEXT", nullable: true),
                    user_name = table.Column<string>(type: "TEXT", nullable: true),
                    password = table.Column<string>(type: "TEXT", nullable: true),
                    liscense_to_kill = table.Column<string>(type: "TEXT", nullable: true),
                    selected_hospital_id = table.Column<string>(type: "TEXT", nullable: true),
                    active = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Epaas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    EpaId = table.Column<int>(type: "INTEGER", nullable: false),
                    name = table.Column<string>(type: "TEXT", nullable: true),
                    category = table.Column<string>(type: "TEXT", nullable: true),
                    year = table.Column<int>(type: "INTEGER", nullable: false),
                    finished = table.Column<bool>(type: "INTEGER", nullable: false),
                    created = table.Column<DateTime>(type: "TEXT", nullable: false),
                    image = table.Column<string>(type: "TEXT", nullable: true),
                    date_started = table.Column<DateTime>(type: "TEXT", nullable: false),
                    date_finished = table.Column<DateTime>(type: "TEXT", nullable: false),
                    grade = table.Column<string>(type: "TEXT", nullable: true),
                    option_1 = table.Column<string>(type: "TEXT", nullable: true),
                    option_2 = table.Column<string>(type: "TEXT", nullable: true),
                    option_3 = table.Column<string>(type: "TEXT", nullable: true),
                    option_4 = table.Column<string>(type: "TEXT", nullable: true),
                    option_5 = table.Column<string>(type: "TEXT", nullable: true),
                    option_6 = table.Column<string>(type: "TEXT", nullable: true),
                    option_7 = table.Column<string>(type: "TEXT", nullable: true),
                    userId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Epaas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Epaas_AspNetUsers_userId",
                        column: x => x.userId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "finalReports",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    procedure_id = table.Column<int>(type: "INTEGER", nullable: false),
                    MedRecNumber = table.Column<string>(type: "TEXT", nullable: true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    ProcedureDescription = table.Column<string>(type: "TEXT", nullable: true),
                    Attending = table.Column<string>(type: "TEXT", nullable: true),
                    OperatieDate = table.Column<string>(type: "TEXT", nullable: true),
                    Diagnosis = table.Column<string>(type: "TEXT", nullable: true),
                    Surgeon = table.Column<string>(type: "TEXT", nullable: true),
                    Assistant = table.Column<string>(type: "TEXT", nullable: true),
                    Perfusionist = table.Column<string>(type: "TEXT", nullable: true),
                    Anaesthesist = table.Column<string>(type: "TEXT", nullable: true),
                    FreeText = table.Column<string>(type: "TEXT", nullable: true),
                    HeaderText1 = table.Column<string>(type: "TEXT", nullable: true),
                    HeaderText2 = table.Column<string>(type: "TEXT", nullable: true),
                    HeaderText3 = table.Column<string>(type: "TEXT", nullable: true),
                    HeaderText4 = table.Column<string>(type: "TEXT", nullable: true),
                    HeaderText5 = table.Column<string>(type: "TEXT", nullable: true),
                    HeaderText6 = table.Column<string>(type: "TEXT", nullable: true),
                    HeaderText7 = table.Column<string>(type: "TEXT", nullable: true),
                    HeaderText8 = table.Column<string>(type: "TEXT", nullable: true),
                    HeaderText9 = table.Column<string>(type: "TEXT", nullable: true),
                    Regel1 = table.Column<string>(type: "TEXT", nullable: true),
                    Regel2 = table.Column<string>(type: "TEXT", nullable: true),
                    Regel3 = table.Column<string>(type: "TEXT", nullable: true),
                    Regel4 = table.Column<string>(type: "TEXT", nullable: true),
                    Regel5 = table.Column<string>(type: "TEXT", nullable: true),
                    Regel6 = table.Column<string>(type: "TEXT", nullable: true),
                    Regel7 = table.Column<string>(type: "TEXT", nullable: true),
                    Regel8 = table.Column<string>(type: "TEXT", nullable: true),
                    Regel9 = table.Column<string>(type: "TEXT", nullable: true),
                    Regel10 = table.Column<string>(type: "TEXT", nullable: true),
                    Regel11 = table.Column<string>(type: "TEXT", nullable: true),
                    Regel12 = table.Column<string>(type: "TEXT", nullable: true),
                    Regel13 = table.Column<string>(type: "TEXT", nullable: true),
                    Regel14 = table.Column<string>(type: "TEXT", nullable: true),
                    Regel15 = table.Column<string>(type: "TEXT", nullable: true),
                    Regel16 = table.Column<string>(type: "TEXT", nullable: true),
                    Regel17 = table.Column<string>(type: "TEXT", nullable: true),
                    Regel18 = table.Column<string>(type: "TEXT", nullable: true),
                    Regel19 = table.Column<string>(type: "TEXT", nullable: true),
                    Regel20 = table.Column<string>(type: "TEXT", nullable: true),
                    Regel21 = table.Column<string>(type: "TEXT", nullable: true),
                    Regel22 = table.Column<string>(type: "TEXT", nullable: true),
                    Regel23 = table.Column<string>(type: "TEXT", nullable: true),
                    Regel24 = table.Column<string>(type: "TEXT", nullable: true),
                    Regel25 = table.Column<string>(type: "TEXT", nullable: true),
                    Regel26 = table.Column<string>(type: "TEXT", nullable: true),
                    Regel27 = table.Column<string>(type: "TEXT", nullable: true),
                    Regel28 = table.Column<string>(type: "TEXT", nullable: true),
                    Regel29 = table.Column<string>(type: "TEXT", nullable: true),
                    Regel30 = table.Column<string>(type: "TEXT", nullable: true),
                    Regel31 = table.Column<string>(type: "TEXT", nullable: true),
                    Regel32 = table.Column<string>(type: "TEXT", nullable: true),
                    Regel33 = table.Column<string>(type: "TEXT", nullable: true),
                    Regel34 = table.Column<string>(type: "TEXT", nullable: true),
                    Regel35 = table.Column<string>(type: "TEXT", nullable: true),
                    Regel36 = table.Column<string>(type: "TEXT", nullable: true),
                    Regel37 = table.Column<string>(type: "TEXT", nullable: true),
                    Regel38 = table.Column<string>(type: "TEXT", nullable: true),
                    Regel39 = table.Column<string>(type: "TEXT", nullable: true),
                    Regel40 = table.Column<string>(type: "TEXT", nullable: true),
                    Regel41 = table.Column<string>(type: "TEXT", nullable: true),
                    Regel42 = table.Column<string>(type: "TEXT", nullable: true),
                    Regel43 = table.Column<string>(type: "TEXT", nullable: true),
                    Regel44 = table.Column<string>(type: "TEXT", nullable: true),
                    Regel45 = table.Column<string>(type: "TEXT", nullable: true),
                    Regel46 = table.Column<string>(type: "TEXT", nullable: true),
                    Regel47 = table.Column<string>(type: "TEXT", nullable: true),
                    Regel48 = table.Column<string>(type: "TEXT", nullable: true),
                    Regel49 = table.Column<string>(type: "TEXT", nullable: true),
                    Regel50 = table.Column<string>(type: "TEXT", nullable: true),
                    Regel51 = table.Column<string>(type: "TEXT", nullable: true),
                    Regel52 = table.Column<string>(type: "TEXT", nullable: true),
                    Regel53 = table.Column<string>(type: "TEXT", nullable: true),
                    Regel54 = table.Column<string>(type: "TEXT", nullable: true),
                    Regel55 = table.Column<string>(type: "TEXT", nullable: true),
                    Regel56 = table.Column<string>(type: "TEXT", nullable: true),
                    Regel57 = table.Column<string>(type: "TEXT", nullable: true),
                    Regel58 = table.Column<string>(type: "TEXT", nullable: true),
                    Regel59 = table.Column<string>(type: "TEXT", nullable: true),
                    Regel60 = table.Column<string>(type: "TEXT", nullable: true),
                    Regel61 = table.Column<string>(type: "TEXT", nullable: true),
                    Regel62 = table.Column<string>(type: "TEXT", nullable: true),
                    Regel63 = table.Column<string>(type: "TEXT", nullable: true),
                    Comment1 = table.Column<string>(type: "TEXT", nullable: true),
                    Comment2 = table.Column<string>(type: "TEXT", nullable: true),
                    Comment3 = table.Column<string>(type: "TEXT", nullable: true),
                    UserName = table.Column<string>(type: "TEXT", nullable: true),
                    HospitalUrl = table.Column<string>(type: "TEXT", nullable: true),
                    AorticLineA = table.Column<string>(type: "TEXT", nullable: true),
                    AorticLineB = table.Column<string>(type: "TEXT", nullable: true),
                    AorticLineC = table.Column<string>(type: "TEXT", nullable: true),
                    MitralLineA = table.Column<string>(type: "TEXT", nullable: true),
                    MitralLineB = table.Column<string>(type: "TEXT", nullable: true),
                    MitralLineC = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_finalReports", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Hospitals",
                columns: table => new
                {
                    hospitalId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Selected_Hospital_Name = table.Column<string>(type: "TEXT", nullable: true),
                    HospitalName = table.Column<string>(type: "TEXT", nullable: true),
                    HospitalNo = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    Address = table.Column<string>(type: "TEXT", nullable: true),
                    Telephone = table.Column<string>(type: "TEXT", nullable: true),
                    Fax = table.Column<string>(type: "TEXT", nullable: true),
                    City = table.Column<string>(type: "TEXT", nullable: true),
                    Country = table.Column<string>(type: "TEXT", nullable: true),
                    SampleMrn = table.Column<string>(type: "TEXT", nullable: true),
                    RegExpr = table.Column<string>(type: "TEXT", nullable: true),
                    usesOnlineValveInventory = table.Column<bool>(type: "INTEGER", nullable: false),
                    ImageUrl = table.Column<string>(type: "TEXT", nullable: true),
                    OpReportDetails1 = table.Column<string>(type: "TEXT", nullable: true),
                    OpReportDetails2 = table.Column<string>(type: "TEXT", nullable: true),
                    OpReportDetails3 = table.Column<string>(type: "TEXT", nullable: true),
                    OpReportDetails4 = table.Column<string>(type: "TEXT", nullable: true),
                    OpReportDetails5 = table.Column<string>(type: "TEXT", nullable: true),
                    OpReportDetails6 = table.Column<string>(type: "TEXT", nullable: true),
                    OpReportDetails7 = table.Column<string>(type: "TEXT", nullable: true),
                    OpReportDetails8 = table.Column<string>(type: "TEXT", nullable: true),
                    OpReportDetails9 = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hospitals", x => x.hospitalId);
                });

            migrationBuilder.CreateTable(
                name: "LTXs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PROCEDURE_ID = table.Column<int>(type: "INTEGER", nullable: false),
                    Indication = table.Column<string>(type: "TEXT", nullable: true),
                    TypeOfTX = table.Column<string>(type: "TEXT", nullable: true),
                    startHr01 = table.Column<string>(type: "TEXT", nullable: true),
                    startHr02 = table.Column<string>(type: "TEXT", nullable: true),
                    startHr03 = table.Column<string>(type: "TEXT", nullable: true),
                    startHr04 = table.Column<string>(type: "TEXT", nullable: true),
                    startMin01 = table.Column<string>(type: "TEXT", nullable: true),
                    startMin02 = table.Column<string>(type: "TEXT", nullable: true),
                    startMin03 = table.Column<string>(type: "TEXT", nullable: true),
                    startMin04 = table.Column<string>(type: "TEXT", nullable: true),
                    AcceptorProcedureStart = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DonorProcedureStart = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DonorStartIschemia = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DonorStartReperfusion = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LTXs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MinInvs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PROCEDURE_ID = table.Column<int>(type: "INTEGER", nullable: false),
                    STRATEGY = table.Column<int>(type: "INTEGER", nullable: false),
                    PRIMARY_INCISION = table.Column<int>(type: "INTEGER", nullable: false),
                    PRIMARY_INCISION_DETAILS = table.Column<int>(type: "INTEGER", nullable: false),
                    NUMBER_OF_INCISIONS = table.Column<int>(type: "INTEGER", nullable: false),
                    CONVERSION_TO_STANDARD = table.Column<int>(type: "INTEGER", nullable: false),
                    CONVERSION_DETAILS = table.Column<int>(type: "INTEGER", nullable: false),
                    ROBOT = table.Column<int>(type: "INTEGER", nullable: false),
                    ROBOT_CABG = table.Column<int>(type: "INTEGER", nullable: false),
                    ROBOT_AORTIC = table.Column<int>(type: "INTEGER", nullable: false),
                    ROBOT_MITRAL = table.Column<int>(type: "INTEGER", nullable: false),
                    ROBOT_TRICUSPID = table.Column<int>(type: "INTEGER", nullable: false),
                    ROBOT_PULMONARY = table.Column<int>(type: "INTEGER", nullable: false),
                    LIMA_HARVEST = table.Column<int>(type: "INTEGER", nullable: false),
                    VESSEL = table.Column<int>(type: "INTEGER", nullable: false),
                    SHUNT = table.Column<int>(type: "INTEGER", nullable: false),
                    LAD_TIME = table.Column<int>(type: "INTEGER", nullable: false),
                    RCA_TIME = table.Column<int>(type: "INTEGER", nullable: false),
                    CX_TIME = table.Column<int>(type: "INTEGER", nullable: false),
                    AL_TIME = table.Column<int>(type: "INTEGER", nullable: false),
                    SUTURE = table.Column<int>(type: "INTEGER", nullable: false),
                    ACUTE_FLOW = table.Column<int>(type: "INTEGER", nullable: false),
                    ACUTE_FLOW_DETAILS = table.Column<int>(type: "INTEGER", nullable: false),
                    IABP = table.Column<int>(type: "INTEGER", nullable: false),
                    IABP_WHEN = table.Column<int>(type: "INTEGER", nullable: false),
                    IABP_WHY = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MinInvs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    PatientId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MRN = table.Column<string>(type: "TEXT", nullable: true),
                    EuroScoreNo = table.Column<int>(type: "INTEGER", nullable: false),
                    Age = table.Column<int>(type: "INTEGER", nullable: false),
                    soort_procedure = table.Column<int>(type: "INTEGER", nullable: false),
                    Id = table.Column<int>(type: "INTEGER", nullable: false),
                    dead = table.Column<int>(type: "INTEGER", nullable: false),
                    gender = table.Column<string>(type: "TEXT", nullable: true),
                    extra_cardiac_arteriopathy = table.Column<string>(type: "TEXT", nullable: true),
                    poor_mobility = table.Column<string>(type: "TEXT", nullable: true),
                    previous_cardiac_surgery = table.Column<string>(type: "TEXT", nullable: true),
                    IsPreviousIntervention = table.Column<string>(type: "TEXT", nullable: true),
                    copd = table.Column<string>(type: "TEXT", nullable: true),
                    active_endocarditis = table.Column<string>(type: "TEXT", nullable: true),
                    critical_preoperative_state = table.Column<bool>(type: "INTEGER", nullable: false),
                    diabetes_on_insulin = table.Column<string>(type: "TEXT", nullable: true),
                    NYHA = table.Column<string>(type: "TEXT", nullable: true),
                    CCS = table.Column<string>(type: "TEXT", nullable: true),
                    LVEF = table.Column<string>(type: "TEXT", nullable: true),
                    recent_mi = table.Column<string>(type: "TEXT", nullable: true),
                    NOPM = table.Column<string>(type: "TEXT", nullable: true),
                    systolic_pa_pressure = table.Column<string>(type: "TEXT", nullable: true),
                    timing = table.Column<string>(type: "TEXT", nullable: true),
                    reason_urgent = table.Column<string>(type: "TEXT", nullable: true),
                    reason_emergent = table.Column<string>(type: "TEXT", nullable: true),
                    weight_of_intervention = table.Column<string>(type: "TEXT", nullable: true),
                    surgery_on_thoracic_aorta = table.Column<string>(type: "TEXT", nullable: true),
                    weight = table.Column<string>(type: "TEXT", nullable: true),
                    height = table.Column<string>(type: "TEXT", nullable: true),
                    creat_number = table.Column<int>(type: "INTEGER", nullable: false),
                    dialysis = table.Column<bool>(type: "INTEGER", nullable: false),
                    crit_shock = table.Column<bool>(type: "INTEGER", nullable: false),
                    crit_inotropes = table.Column<bool>(type: "INTEGER", nullable: false),
                    crit_arrythmia = table.Column<bool>(type: "INTEGER", nullable: false),
                    crit_resuscitation = table.Column<bool>(type: "INTEGER", nullable: false),
                    crit_iabp = table.Column<bool>(type: "INTEGER", nullable: false),
                    crit_ventilated = table.Column<bool>(type: "INTEGER", nullable: false),
                    crit_renal_failure = table.Column<bool>(type: "INTEGER", nullable: false),
                    crit_pacemaker = table.Column<bool>(type: "INTEGER", nullable: false),
                    log_score = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.PatientId);
                });

            migrationBuilder.CreateTable(
                name: "PostOps",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PROCEDURE_ID = table.Column<int>(type: "INTEGER", nullable: false),
                    PATIENT_ID = table.Column<int>(type: "INTEGER", nullable: false),
                    ICU_ARRIVAL_DATE = table.Column<DateTime>(type: "TEXT", nullable: false),
                    EXTUBATION_DATE = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DISCHARGE_DATE = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ICU_DISCHARGE_DATE = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ICU_ARRIVAL_1_DATE = table.Column<DateTime>(type: "TEXT", nullable: false),
                    EXTUBATION_1_DATE = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ICU_DISCHARGE_1_DATE = table.Column<DateTime>(type: "TEXT", nullable: false),
                    REINTUBATION_DATE = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ICU_Stay_1 = table.Column<string>(type: "TEXT", nullable: true),
                    ICU_Stay_2 = table.Column<string>(type: "TEXT", nullable: true),
                    ICU_Stay_3 = table.Column<string>(type: "TEXT", nullable: true),
                    Vent_Stay_1 = table.Column<string>(type: "TEXT", nullable: true),
                    Vent_Stay_2 = table.Column<string>(type: "TEXT", nullable: true),
                    Vent_Stay_3 = table.Column<string>(type: "TEXT", nullable: true),
                    Blood_Products = table.Column<string>(type: "TEXT", nullable: true),
                    Autologous_Blood = table.Column<string>(type: "TEXT", nullable: true),
                    PC = table.Column<int>(type: "INTEGER", nullable: false),
                    FFP = table.Column<int>(type: "INTEGER", nullable: false),
                    Platelets = table.Column<int>(type: "INTEGER", nullable: false),
                    When_Used = table.Column<string>(type: "TEXT", nullable: true),
                    complicatie_1 = table.Column<string>(type: "TEXT", nullable: true),
                    complicatie_2 = table.Column<string>(type: "TEXT", nullable: true),
                    complicatie_3 = table.Column<string>(type: "TEXT", nullable: true),
                    complicatie_4 = table.Column<string>(type: "TEXT", nullable: true),
                    complicatie_5 = table.Column<string>(type: "TEXT", nullable: true),
                    complicatie_6 = table.Column<string>(type: "TEXT", nullable: true),
                    complicatie_7 = table.Column<string>(type: "TEXT", nullable: true),
                    complicatie_8 = table.Column<string>(type: "TEXT", nullable: true),
                    complicatie_9 = table.Column<string>(type: "TEXT", nullable: true),
                    mortality_date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    highest_creatinine = table.Column<string>(type: "TEXT", nullable: true),
                    readmitted = table.Column<string>(type: "TEXT", nullable: true),
                    reintubated = table.Column<string>(type: "TEXT", nullable: true),
                    overleden_na_deze_operatie = table.Column<short>(type: "INTEGER", nullable: false),
                    dead_location = table.Column<short>(type: "INTEGER", nullable: false),
                    dead_cause = table.Column<short>(type: "INTEGER", nullable: false),
                    full_description = table.Column<string>(type: "TEXT", nullable: true),
                    activities_discharge = table.Column<string>(type: "TEXT", nullable: true),
                    discharge_diagnosis = table.Column<short>(type: "INTEGER", nullable: false),
                    sent_to = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostOps", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Previews",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    procedure_id = table.Column<int>(type: "INTEGER", nullable: false),
                    regel_1 = table.Column<string>(type: "TEXT", nullable: true),
                    regel_2 = table.Column<string>(type: "TEXT", nullable: true),
                    regel_3 = table.Column<string>(type: "TEXT", nullable: true),
                    regel_4 = table.Column<string>(type: "TEXT", nullable: true),
                    regel_5 = table.Column<string>(type: "TEXT", nullable: true),
                    regel_6 = table.Column<string>(type: "TEXT", nullable: true),
                    regel_7 = table.Column<string>(type: "TEXT", nullable: true),
                    regel_8 = table.Column<string>(type: "TEXT", nullable: true),
                    regel_9 = table.Column<string>(type: "TEXT", nullable: true),
                    regel_10 = table.Column<string>(type: "TEXT", nullable: true),
                    regel_11 = table.Column<string>(type: "TEXT", nullable: true),
                    regel_12 = table.Column<string>(type: "TEXT", nullable: true),
                    regel_13 = table.Column<string>(type: "TEXT", nullable: true),
                    regel_14 = table.Column<string>(type: "TEXT", nullable: true),
                    regel_15 = table.Column<string>(type: "TEXT", nullable: true),
                    regel_16 = table.Column<string>(type: "TEXT", nullable: true),
                    regel_17 = table.Column<string>(type: "TEXT", nullable: true),
                    regel_18 = table.Column<string>(type: "TEXT", nullable: true),
                    regel_19 = table.Column<string>(type: "TEXT", nullable: true),
                    regel_20 = table.Column<string>(type: "TEXT", nullable: true),
                    regel_21 = table.Column<string>(type: "TEXT", nullable: true),
                    regel_22 = table.Column<string>(type: "TEXT", nullable: true),
                    regel_23 = table.Column<string>(type: "TEXT", nullable: true),
                    regel_24 = table.Column<string>(type: "TEXT", nullable: true),
                    regel_25 = table.Column<string>(type: "TEXT", nullable: true),
                    regel_26 = table.Column<string>(type: "TEXT", nullable: true),
                    regel_27 = table.Column<string>(type: "TEXT", nullable: true),
                    regel_28 = table.Column<string>(type: "TEXT", nullable: true),
                    regel_29 = table.Column<string>(type: "TEXT", nullable: true),
                    regel_30 = table.Column<string>(type: "TEXT", nullable: true),
                    regel_31 = table.Column<string>(type: "TEXT", nullable: true),
                    regel_32 = table.Column<string>(type: "TEXT", nullable: true),
                    regel_33 = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Previews", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RefPhys",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    hospital_id = table.Column<int>(type: "INTEGER", nullable: false),
                    name = table.Column<string>(type: "TEXT", nullable: true),
                    image = table.Column<string>(type: "TEXT", nullable: true),
                    address = table.Column<string>(type: "TEXT", nullable: true),
                    street = table.Column<string>(type: "TEXT", nullable: true),
                    postcode = table.Column<string>(type: "TEXT", nullable: true),
                    city = table.Column<string>(type: "TEXT", nullable: true),
                    state = table.Column<string>(type: "TEXT", nullable: true),
                    country = table.Column<string>(type: "TEXT", nullable: true),
                    tel = table.Column<string>(type: "TEXT", nullable: true),
                    fax = table.Column<string>(type: "TEXT", nullable: true),
                    email = table.Column<string>(type: "TEXT", nullable: true),
                    send_email = table.Column<bool>(type: "INTEGER", nullable: false),
                    active = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefPhys", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Suggestions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    soort = table.Column<int>(type: "INTEGER", nullable: false),
                    user = table.Column<string>(type: "TEXT", nullable: true),
                    regel_1_a = table.Column<string>(type: "TEXT", nullable: true),
                    regel_1_b = table.Column<string>(type: "TEXT", nullable: true),
                    regel_1_c = table.Column<string>(type: "TEXT", nullable: true),
                    regel_2_a = table.Column<string>(type: "TEXT", nullable: true),
                    regel_2_b = table.Column<string>(type: "TEXT", nullable: true),
                    regel_2_c = table.Column<string>(type: "TEXT", nullable: true),
                    regel_3_a = table.Column<string>(type: "TEXT", nullable: true),
                    regel_3_b = table.Column<string>(type: "TEXT", nullable: true),
                    regel_3_c = table.Column<string>(type: "TEXT", nullable: true),
                    regel_4_a = table.Column<string>(type: "TEXT", nullable: true),
                    regel_4_b = table.Column<string>(type: "TEXT", nullable: true),
                    regel_4_c = table.Column<string>(type: "TEXT", nullable: true),
                    regel_5_a = table.Column<string>(type: "TEXT", nullable: true),
                    regel_5_b = table.Column<string>(type: "TEXT", nullable: true),
                    regel_5_c = table.Column<string>(type: "TEXT", nullable: true),
                    regel_6_a = table.Column<string>(type: "TEXT", nullable: true),
                    regel_6_b = table.Column<string>(type: "TEXT", nullable: true),
                    regel_6_c = table.Column<string>(type: "TEXT", nullable: true),
                    regel_7_a = table.Column<string>(type: "TEXT", nullable: true),
                    regel_7_b = table.Column<string>(type: "TEXT", nullable: true),
                    regel_7_c = table.Column<string>(type: "TEXT", nullable: true),
                    regel_8_a = table.Column<string>(type: "TEXT", nullable: true),
                    regel_8_b = table.Column<string>(type: "TEXT", nullable: true),
                    regel_8_c = table.Column<string>(type: "TEXT", nullable: true),
                    regel_9_a = table.Column<string>(type: "TEXT", nullable: true),
                    regel_9_b = table.Column<string>(type: "TEXT", nullable: true),
                    regel_9_c = table.Column<string>(type: "TEXT", nullable: true),
                    regel_10_a = table.Column<string>(type: "TEXT", nullable: true),
                    regel_10_b = table.Column<string>(type: "TEXT", nullable: true),
                    regel_10_c = table.Column<string>(type: "TEXT", nullable: true),
                    regel_11_a = table.Column<string>(type: "TEXT", nullable: true),
                    regel_11_b = table.Column<string>(type: "TEXT", nullable: true),
                    regel_11_c = table.Column<string>(type: "TEXT", nullable: true),
                    regel_12_a = table.Column<string>(type: "TEXT", nullable: true),
                    regel_12_b = table.Column<string>(type: "TEXT", nullable: true),
                    regel_12_c = table.Column<string>(type: "TEXT", nullable: true),
                    regel_13_a = table.Column<string>(type: "TEXT", nullable: true),
                    regel_13_b = table.Column<string>(type: "TEXT", nullable: true),
                    regel_13_c = table.Column<string>(type: "TEXT", nullable: true),
                    regel_14_a = table.Column<string>(type: "TEXT", nullable: true),
                    regel_14_b = table.Column<string>(type: "TEXT", nullable: true),
                    regel_14_c = table.Column<string>(type: "TEXT", nullable: true),
                    regel_15 = table.Column<string>(type: "TEXT", nullable: true),
                    regel_16 = table.Column<string>(type: "TEXT", nullable: true),
                    regel_17 = table.Column<string>(type: "TEXT", nullable: true),
                    regel_18 = table.Column<string>(type: "TEXT", nullable: true),
                    regel_19 = table.Column<string>(type: "TEXT", nullable: true),
                    regel_20 = table.Column<string>(type: "TEXT", nullable: true),
                    regel_21 = table.Column<string>(type: "TEXT", nullable: true),
                    regel_22 = table.Column<string>(type: "TEXT", nullable: true),
                    regel_23 = table.Column<string>(type: "TEXT", nullable: true),
                    regel_24 = table.Column<string>(type: "TEXT", nullable: true),
                    regel_25 = table.Column<string>(type: "TEXT", nullable: true),
                    regel_26 = table.Column<string>(type: "TEXT", nullable: true),
                    regel_27 = table.Column<string>(type: "TEXT", nullable: true),
                    regel_28 = table.Column<string>(type: "TEXT", nullable: true),
                    regel_29 = table.Column<string>(type: "TEXT", nullable: true),
                    regel_30 = table.Column<string>(type: "TEXT", nullable: true),
                    regel_31 = table.Column<string>(type: "TEXT", nullable: true),
                    regel_32 = table.Column<string>(type: "TEXT", nullable: true),
                    regel_33 = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suggestions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vlads",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    current_user_id = table.Column<int>(type: "INTEGER", nullable: false),
                    hospitalId = table.Column<int>(type: "INTEGER", nullable: false),
                    caption = table.Column<string>(type: "TEXT", nullable: true),
                    dataXas = table.Column<string>(type: "TEXT", nullable: true),
                    dataYas = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vlads", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RoleId = table.Column<int>(type: "INTEGER", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "INTEGER", nullable: false),
                    RoleId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Class_Valve_Code",
                columns: table => new
                {
                    codeId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    code = table.Column<string>(type: "TEXT", nullable: true),
                    soort = table.Column<int>(type: "INTEGER", nullable: false),
                    valveTypeId = table.Column<int>(type: "INTEGER", nullable: false),
                    description = table.Column<string>(type: "TEXT", nullable: true),
                    position = table.Column<string>(type: "TEXT", nullable: true),
                    type = table.Column<string>(type: "TEXT", nullable: true),
                    hospitalId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Class_Valve_Code", x => x.codeId);
                    table.ForeignKey(
                        name: "FK_Class_Valve_Code_Hospitals_hospitalId",
                        column: x => x.hospitalId,
                        principalTable: "Hospitals",
                        principalColumn: "hospitalId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Procedures",
                columns: table => new
                {
                    ProcedureId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    hospital = table.Column<int>(type: "INTEGER", nullable: false),
                    refPhys = table.Column<int>(type: "INTEGER", nullable: false),
                    emailHash = table.Column<string>(type: "TEXT", nullable: true),
                    Class_PatientPatientId = table.Column<int>(type: "INTEGER", nullable: true),
                    PatientId = table.Column<int>(type: "INTEGER", nullable: false),
                    fdType = table.Column<int>(type: "INTEGER", nullable: false),
                    DateOfSurgery = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Sequence = table.Column<string>(type: "TEXT", nullable: true),
                    SelectedSurgeon = table.Column<int>(type: "INTEGER", nullable: false),
                    SelectedResponsibleSurgeon = table.Column<int>(type: "INTEGER", nullable: false),
                    SelectedAnaesthesist = table.Column<int>(type: "INTEGER", nullable: false),
                    SelectedAssistant = table.Column<int>(type: "INTEGER", nullable: false),
                    SelectedPerfusionist = table.Column<int>(type: "INTEGER", nullable: false),
                    SelectedNurse1 = table.Column<int>(type: "INTEGER", nullable: false),
                    SelectedNurse2 = table.Column<int>(type: "INTEGER", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    SurgeryBeforeNextWorkingDay = table.Column<bool>(type: "INTEGER", nullable: false),
                    SelectedTiming = table.Column<int>(type: "INTEGER", nullable: false),
                    SelectedUrgentTiming = table.Column<int>(type: "INTEGER", nullable: false),
                    SelectedEmergencyTiming = table.Column<int>(type: "INTEGER", nullable: false),
                    SelectedStartHr = table.Column<int>(type: "INTEGER", nullable: false),
                    SelectedStartMin = table.Column<int>(type: "INTEGER", nullable: false),
                    SelectedStopHr = table.Column<int>(type: "INTEGER", nullable: false),
                    SelectedStopMin = table.Column<int>(type: "INTEGER", nullable: false),
                    TotalTime = table.Column<int>(type: "INTEGER", nullable: false),
                    SelectedInotropes = table.Column<int>(type: "INTEGER", nullable: false),
                    SelectedPacemaker = table.Column<int>(type: "INTEGER", nullable: false),
                    SelectedPericard = table.Column<int>(type: "INTEGER", nullable: false),
                    SelectedPleura = table.Column<int>(type: "INTEGER", nullable: false),
                    Comment1 = table.Column<string>(type: "TEXT", nullable: true),
                    Comment2 = table.Column<string>(type: "TEXT", nullable: true),
                    Comment3 = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Procedures", x => x.ProcedureId);
                    table.ForeignKey(
                        name: "FK_Procedures_Patients_Class_PatientPatientId",
                        column: x => x.Class_PatientPatientId,
                        principalTable: "Patients",
                        principalColumn: "PatientId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Valves",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Implant_Position = table.Column<string>(type: "TEXT", nullable: true),
                    IMPLANT = table.Column<string>(type: "TEXT", nullable: true),
                    EXPLANT = table.Column<string>(type: "TEXT", nullable: true),
                    SIZE = table.Column<string>(type: "TEXT", nullable: true),
                    TYPE = table.Column<string>(type: "TEXT", nullable: true),
                    SIZE_EXP = table.Column<string>(type: "TEXT", nullable: true),
                    TYPE_EXP = table.Column<int>(type: "INTEGER", nullable: true),
                    ProcedureType = table.Column<string>(type: "TEXT", nullable: true),
                    ProcedureAetiology = table.Column<string>(type: "TEXT", nullable: true),
                    MODEL = table.Column<string>(type: "TEXT", nullable: true),
                    MODEL_EXP = table.Column<string>(type: "TEXT", nullable: true),
                    SERIAL_IMP = table.Column<string>(type: "TEXT", nullable: true),
                    SERIAL_EXP = table.Column<string>(type: "TEXT", nullable: true),
                    RING_USED = table.Column<string>(type: "TEXT", nullable: true),
                    REPAIR_TYPE = table.Column<string>(type: "TEXT", nullable: true),
                    Memo = table.Column<string>(type: "TEXT", nullable: true),
                    Combined = table.Column<string>(type: "TEXT", nullable: true),
                    ProcedureId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Valves", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Valves_Procedures_ProcedureId",
                        column: x => x.ProcedureId,
                        principalTable: "Procedures",
                        principalColumn: "ProcedureId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Class_Valve_Code_hospitalId",
                table: "Class_Valve_Code",
                column: "hospitalId");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_userId",
                table: "Courses",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_Epaas_userId",
                table: "Epaas",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_Procedures_Class_PatientPatientId",
                table: "Procedures",
                column: "Class_PatientPatientId");

            migrationBuilder.CreateIndex(
                name: "IX_Valves_ProcedureId",
                table: "Valves",
                column: "ProcedureId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AorticSurgeries");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "CABGS");

            migrationBuilder.DropTable(
                name: "Class_Valve_Code");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "CPBS");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Epaas");

            migrationBuilder.DropTable(
                name: "finalReports");

            migrationBuilder.DropTable(
                name: "LTXs");

            migrationBuilder.DropTable(
                name: "MinInvs");

            migrationBuilder.DropTable(
                name: "PostOps");

            migrationBuilder.DropTable(
                name: "Previews");

            migrationBuilder.DropTable(
                name: "RefPhys");

            migrationBuilder.DropTable(
                name: "Suggestions");

            migrationBuilder.DropTable(
                name: "Valves");

            migrationBuilder.DropTable(
                name: "Vlads");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Hospitals");

            migrationBuilder.DropTable(
                name: "Procedures");

            migrationBuilder.DropTable(
                name: "Patients");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetUsers",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "EmailIndex",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "UserNameIndex",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "AccessFailedCount",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "City",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ConcurrencyStamp",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Created",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "DateOfBirth",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "EmailConfirmed",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "IBAN",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Interests",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Introduction",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "KnownAs",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastActive",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LockoutEnabled",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LockoutEnd",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LookingFor",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Mobile",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "NormalizedEmail",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "NormalizedUserName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "PhoneNumberConfirmed",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "PhotoUrl",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "SecurityStamp",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "TwoFactorEnabled",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "active",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "hospital_id",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ltk",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "worked_in",
                table: "AspNetUsers");

            migrationBuilder.RenameTable(
                name: "AspNetUsers",
                newName: "Users");

            migrationBuilder.AlterColumn<byte[]>(
                name: "PasswordHash",
                table: "Users",
                type: "BLOB",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");
        }
    }
}
