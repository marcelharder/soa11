
using System.Collections.Generic;
using System.Threading.Tasks;
using api.Data;
using api.Entities;
using api.Helpers;
using api.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{

    [ApiController]
    // [Authorize]
    public class DropDownController : ControllerBase
    {
       // private IUserRepository _repo;
        private IHospitalRepository _hos;
        private IEmployeeRepository _emp;
        private SpecialMaps _sp;
        List<Class_Item> _result = new List<Class_Item>();

        private OperatieDrops _copd;
        public DropDownController(
          //  IUserRepository repo,
            SpecialMaps sp,
            IEmployeeRepository emp,
            IHospitalRepository hos,
            OperatieDrops copd)
        {
         //   _repo = repo;
            _emp = emp;
            _copd = copd;
            _hos = hos;
            _sp = sp;
        }

        #region <!--hospitalStuff -->

        [Route("api/hospitalOptions/{id}")]
        [HttpGet]
        public async Task<IActionResult> getHO(int id)
        {
            _result = await _copd.getHospitalOptions(id); return Ok(_result);
        }
        [Route("api/allHospitals")]
        [HttpGet]
        public IActionResult getHO()
        {
            var test = _hos.GetAllHospitals(); 
            return Ok(test);
        }

        [Route("api/allHospitalOptionsPerCountry/{id}")]
        [HttpGet]
        public async Task<IActionResult> getHp(int id)
        {
            var countryCode = _sp.getCountryFromCode(id);
            _result = await _copd.getAllHospitalsPerCountry(countryCode);
            return Ok(_result);
        }

        #endregion
        #region <!--cities-->
        [Route("api/countriesDrops")]// get all the countries with possibe hospitals
        [HttpGet]
        public IActionResult getThing02()
        {
            var result = _hos.GetAllCountries();
            return Ok(result);
        }
        [Route("api/citiesDrops")]
        [HttpGet]
        public IActionResult getThing12()
        {
            var result = _hos.GetAllCities();
            return Ok(result);
        }
        [Route("api/citiesPerCountry/{id}")]
        [HttpGet]
        public IActionResult getThing122(int id)
        {
            var result = _hos.GetAllCitiesPerCountry(id);
            return Ok(result);
        }
        #endregion
        #region <!--cpb -->
        
        [Route("api/iabp_when")]
        [HttpGet]
        public async Task<IActionResult> getGeneral_073() { _result = await _copd.getCPB_iabp_timing(); return Ok(_result); }
        [Route("api/iabp_why")]
        [HttpGet]
        public async Task<IActionResult> getGeneral_074() { _result = await _copd.getCPB_iabp_ind(); return Ok(_result); }

        [Route("api/art_canulation_options")]
        [HttpGet]
        public async Task<IActionResult> getAa()
        {
            var result = await _copd.getCPB_art_choice();

            return Ok(result);
        }
        [Route("api/ven_canulation_options")]
        [HttpGet]
        public async Task<IActionResult> getAb()
        {
            var result = await _copd.getCPB_ven_choice();

            return Ok(result);
        }
        [Route("api/occl_method")]
        [HttpGet]
        public async Task<IActionResult> getAc()
        {
            var result = await _copd.getCPB_aox();

            return Ok(result);
        }
        [Route("api/myotech")]
        [HttpGet]
        public async Task<IActionResult> getAd()
        {
            var result = await _copd.getCPB_nccp();

            return Ok(result);
        }
        [Route("api/cardioplegtiming")]
        [HttpGet]
        public async Task<IActionResult> getAe()
        {
            var result = await _copd.getCPB_timing();

            return Ok(result);
        }
        [Route("api/mpt")]
        [HttpGet]
        public async Task<IActionResult> getAe2()
        {
            var result = await _copd.getMPT();

            return Ok(result);
        }
        [Route("api/cardioplegtemp")]
        [HttpGet]
        public async Task<IActionResult> getAh()
        {
            var result = await _copd.getCPB_temp();

            return Ok(result);
        }
        [Route("api/cardioplegdelivery")]
        [HttpGet]
        public async Task<IActionResult> getAf()
        {
            var result = await _copd.getCPB_delivery();

            return Ok(result);
        }
        [Route("api/typeCardiopleg")]
        [HttpGet]
        public async Task<IActionResult> getAhy()
        {
            var result = await _copd.getTypeCardiopleg();

            return Ok(result);
        }
        [Route("api/myocardialPreservationTechnique")]
        [HttpGet]
        public async Task<IActionResult> getMPT()
        {
            _result = await _copd.getMPT(); return Ok(_result);
        }

        [Route("api/art_choice")]
        [HttpGet]
        public async Task<IActionResult> getCPB_01() { _result = await _copd.getCPB_art_choice(); return Ok(_result); }
        [Route("api/ven_choice")]
        [HttpGet]
        public async Task<IActionResult> getCPB_02() { _result = await _copd.getCPB_ven_choice(); return Ok(_result); }

        [Route("api/cpb_delivery")]
        [HttpGet]
        public async Task<IActionResult> getCPB_03() { _result = await _copd.getCPB_delivery(); return Ok(_result); }
        [Route("api/iabp_ind")]
        [HttpGet]
        public async Task<IActionResult> getCPB_04() { _result = await _copd.getCPB_iabp_ind(); return Ok(_result); }
        [Route("api/iabp_timing")]
        [HttpGet]
        public async Task<IActionResult> getCPB_05() { _result = await _copd.getCPB_iabp_timing(); return Ok(_result); }
        [Route("api/cpb_nccp")]
        [HttpGet]
        public async Task<IActionResult> getCPB_06() { _result = await _copd.getCPB_nccp(); return Ok(_result); }
        [Route("api/cpb_aox")]
        [HttpGet]
        public async Task<IActionResult> getCPB_07() { _result = await _copd.getCPB_aox(); return Ok(_result); }
        [Route("api/cpb_timing")]
        [HttpGet]
        public async Task<IActionResult> getCPB_08() { _result = await _copd.getCPB_timing(); return Ok(_result); }
        [Route("api/cpb_temp")]
        [HttpGet]
        public async Task<IActionResult> getCPB_09() { _result = await _copd.getCPB_temp(); return Ok(_result); }

        #endregion
        #region <!--valve options-->
        [Route("api/implantPosition")]
        [HttpGet]
        public async Task<IActionResult> getIp()
        {
            var result = await _copd.getImplantPositionAsync();
            return Ok(result);
        }

        [Route("api/aorticProcedure")]
        [HttpGet]
        public async Task<IActionResult> getAhx()
        {
            var result = await _copd.getAorticProcedure();

            return Ok(result);
        }
        [Route("api/mitralProcedure")]
        [HttpGet]
        public async Task<IActionResult> getAhz()
        {
            var result = await _copd.getMitralProcedure();

            return Ok(result);
        }
        [Route("api/aetiology")]
        [HttpGet]
        public async Task<IActionResult> getAha()
        {
            var result = await _copd.getValveAetiology();

            return Ok(result);
        }
        [Route("api/tricuspidProcedure")]
        [HttpGet]
        public async Task<IActionResult> getAhd()
        {
            var result = await _copd.getTricuspidProcedure();

            return Ok(result);
        }
        [Route("api/pulmonaryProcedure")]
        [HttpGet]
        public async Task<IActionResult> getAhe()
        {
            var result = await _copd.getPulmonaryProcedure();

            return Ok(result);
        }
        [Route("api/mitralValveRepair")]
        [HttpGet]
        public async Task<IActionResult> getAhf()
        {
            var result = await _copd.getMitralValveRepair();

            return Ok(result);
        }
        [Route("api/tricuspidValveRepair")]
        [HttpGet]
        public async Task<IActionResult> getAhg()
        {
            var result = await _copd.getTricuspidValveRepair();
            return Ok(result);
        }
        [Route("api/valveType")]
        [HttpGet]
        public async Task<IActionResult> getAhh()
        {
            var result = await _copd.getValveType();
            return Ok(result);
        }


        [Route("api/mitralRingType")]
        [HttpGet]
        public IActionResult getAhhw1() // get the data from Valve.xml
        {
            var result = _copd.getMitralRingType();
            return Ok(result);
        }
        [Route("api/tricuspidRingType")]
        [HttpGet]
        public IActionResult getAhhw2() // get the data from Valve.xml
        {
            var result = _copd.getTricuspidRingType();
            return Ok(result);
        }
        #endregion
        #region <!--procedure-->

        [Route("api/timing_options")]
        [HttpGet]
        public async Task<IActionResult> getTO() { await Task.Run(() => { _result = _copd.getTimingOptions(); }); return Ok(_result); }

        [Route("api/urgent_options")]
        [HttpGet]
        public async Task<IActionResult> getUO() { await Task.Run(() => { _result = _copd.getUrgentOptions(); }); return Ok(_result); }

        [Route("api/emergent_options")]
        [HttpGet]
        public async Task<IActionResult> getEO() { await Task.Run(() => { _result = _copd.getEmergentOptions(); }); return Ok(_result); }

        [Route("api/inotrope_options")]
        [HttpGet]
        public async Task<IActionResult> getIO() { await Task.Run(() => { _result = _copd.getInotropeOptions(); }); return Ok(_result); }

        [Route("api/pacemaker_options")]
        [HttpGet]
        public async Task<IActionResult> getPO() { await Task.Run(() => { _result = _copd.getPacemakerOptions(); }); return Ok(_result); }

        [Route("api/pericard_options")]
        [HttpGet]
        public async Task<IActionResult> getPOT() { await Task.Run(() => { _result = _copd.getPericardOptions(); }); return Ok(_result); }

        [Route("api/pleura_options")]
        [HttpGet]
        public async Task<IActionResult> getPER() { await Task.Run(() => { _result = _copd.getPleuraOptions(); }); return Ok(_result); }

        [Route("api/addProcedureCategory/{id}")]
        [HttpGet]
        public async Task<IActionResult> getPERF(int id) // this used to give a list of procedures to choose from, should come from language_file
        {
            await Task.Run(() => { _result = _copd.getArray(id); }); return Ok(_result);
        }

 #endregion
        #region <!--cabg -->

        [Route("api/cabg_quality")]
        [HttpGet]
        public async Task<IActionResult> getCABG_Quality() { _result = await _copd.getCABGQuality(); return Ok(_result); }

        [Route("api/cabg_diameter")]
        [HttpGet]
        public async Task<IActionResult> getCABG_Diameter() { _result = await _copd.getCABGDiameter(); return Ok(_result); }

        [Route("api/cabg_proximal")]
        [HttpGet]
        public async Task<IActionResult> getCABG_Proximal() { _result = await _copd.getCABGProximal(); return Ok(_result); }

        [Route("api/cabg_locatie")]
        [HttpGet]
        public async Task<IActionResult> getCABG_Locatie() { _result = await _copd.getCABGLocatie(); return Ok(_result); }

        [Route("api/cabg_conduit")]
        [HttpGet]
        public async Task<IActionResult> getCABG_Conduit() { _result = await _copd.getCABGConduit(); return Ok(_result); }

        [Route("api/cabg_type")]
        [HttpGet]
        public async Task<IActionResult> getCABG_Type() { _result = await _copd.getCABGType(); return Ok(_result); }

        [Route("api/cabg_procedure")]
        [HttpGet]
        public async Task<IActionResult> getCABG_Procedure() { _result = await _copd.getCABGProcedure(); return Ok(_result); }

        [Route("api/cabg_angle")]
        [HttpGet]
        public async Task<IActionResult> getCABG_Angle() { _result = await _copd.getCABGAngle(); return Ok(_result); }

        [Route("api/cabg_dropList1")]
        [HttpGet]
        public async Task<IActionResult> getCABG_Droplist1() { _result = await _copd.getCABGDropList1(); return Ok(_result); }

        [Route("api/cabg_radial")]
        [HttpGet]
        public async Task<IActionResult> getCABG_Radial() { _result = await _copd.getCABGRadial(); return Ok(_result); }

        [Route("api/cabg_leg")]
        [HttpGet]
        public async Task<IActionResult> getCABG_Leg() { _result = await _copd.getCABGLeg(); return Ok(_result); }

        #endregion
        #region <!--history-->
        [Route("api/eu_weight_intervention")]
        [HttpGet]
        public async Task<IActionResult> getCPB_11() { _result = await _copd.getWeightIntervention(); return Ok(_result); }
        [Route("api/eu_lv_function")]
        [HttpGet]
        public async Task<IActionResult> getCPB_13() { _result = await _copd.getLVFunction(); return Ok(_result); }

        [Route("api/eu_pulmonary_hypertension")]
        [HttpGet]
        public async Task<IActionResult> getCPB_19() { _result = await _copd.getPulmonaryHypertension(); return Ok(_result); }

        [Route("api/eu_urgency")]
        [HttpGet]
        public async Task<IActionResult> getCPB_14() { _result = await _copd.getUrgency(); return Ok(_result); }
        [Route("api/eu_NYHA")]
        [HttpGet]
        public async Task<IActionResult> getCPB_15() { _result = await _copd.getNYHA(); return Ok(_result); }
        [Route("api/eu_reason_urgent")]
        [HttpGet]
        public async Task<IActionResult> getCPB_16() { _result = await _copd.getReasonUrgent(); return Ok(_result); }
        [Route("api/eu_reason_emergency")]
        [HttpGet]
        public async Task<IActionResult> getCPB_17() { _result = await _copd.getReasonEmergency(); return Ok(_result); }

        #endregion
        #region <!--general stuff-->

        [Route("api/dropEmployee")]
        [HttpGet]
        public async Task<IActionResult> getA([FromQuery] EmployeeParams emp)
        {
            var result = await _emp.GetEmployees(emp);
            return Ok(result);
        }

        [Route("api/dropLtxIndication")]
        [HttpGet]
        public async Task<IActionResult> getA2345()
        {
            var result = await _copd.getLTXIndication();
            return Ok(result);
        }
        [Route("api/dropLtxType")]
        [HttpGet]
        public async Task<IActionResult> getA1345()
        {
            var result = await _copd.getLTXType();
            return Ok(result);
        }

      
        [Route("api/career")]
        [HttpGet]
        public async Task<IActionResult> getCareer()
        {
            var result = await _copd.getCareerItems();
            return Ok(result);
        }
        [Route("api/optionsYN")]
        [HttpGet]
        public async Task<IActionResult> getYN() { _result = await _copd.getYN(); return Ok(_result); }
        [Route("api/dropHours")]
        [HttpGet]
        public IActionResult getHours()
        {
            var _result = new List<string>();
            for (int x = 0; x < 24; x++) { _result.Add(x.ToString()); }
            return Ok(_result);
        }

        [Route("api/dropMins")]
        [HttpGet]
        public IActionResult getMin()
        {
            var _result = new List<string>();
            for (int x = 0; x < 60; x++) { _result.Add(x.ToString()); }
            return Ok(_result);
        }

        [Route("api/gender_options")]
        [HttpGet]
        public async Task<IActionResult> getGeneral_01() { _result = await _copd.getGenderOptions(); return Ok(_result); }
        [Route("api/age_options")]
        [HttpGet]
        public async Task<IActionResult> getGeneral_02() { _result = await _copd.getAgeOptions(); return Ok(_result); }
        [Route("api/weight_options")]
        [HttpGet]
        public async Task<IActionResult> getGeneral_03() { _result = await _copd.getWeightOptions(); return Ok(_result); }
        [Route("api/height_options")]
        [HttpGet]
        public async Task<IActionResult> getGeneral_05() { _result = await _copd.getHeightOptions(); return Ok(_result); }
        [Route("api/creat_options")]
        [HttpGet]
        public async Task<IActionResult> getGeneral_04() { _result = await _copd.getCreatOptions(); return Ok(_result); }

        #endregion
        #region <!--postop -->
        [Route("api/dead")]
        [HttpGet]
        public async Task<IActionResult> getGeneral_051() { _result = await _copd.getDeadOrAlive(); return Ok(_result); }
        [Route("api/dead_location")]
        [HttpGet]
        public async Task<IActionResult> getGeneral_052() { _result = await _copd.getDeadLocation(); return Ok(_result); }
        [Route("api/dead_cause")]
        [HttpGet]
        public async Task<IActionResult> getGeneral_053() { _result = await _copd.getDeadCause(); return Ok(_result); }
        [Route("api/discharge_activities")]
        [HttpGet]
        public async Task<IActionResult> getGeneral_054() { _result = await _copd.getDischargeActivities(); return Ok(_result); }
        [Route("api/discharge_diagnosis")]
        [HttpGet]
        public async Task<IActionResult> getGeneral_055() { _result = await _copd.getDischargeDiagnosis(); return Ok(_result); }
        [Route("api/discharge_direction")]
        [HttpGet]
        public async Task<IActionResult> getGeneral_056() { _result = await _copd.getDischargeDirection(); return Ok(_result); }

        [Route("api/AutoBloodTiming")]
        [HttpGet]
        public async Task<IActionResult> getGeneral_041() { _result = await _copd.getAutologousBloodTiming(); return Ok(_result); }

        [Route("api/complicationOptions01")]
        [HttpGet]
        public async Task<IActionResult> getGeneral_042() { _result = await _copd.getComplicatieOptie01(); return Ok(_result); }
        [Route("api/complicationOptions02")]
        [HttpGet]
        public async Task<IActionResult> getGeneral_043() { _result = await _copd.getComplicatieOptie02(); return Ok(_result); }
        [Route("api/complicationOptions03")]
        [HttpGet]
        public async Task<IActionResult> getGeneral_044() { _result = await _copd.getComplicatieOptie03(); return Ok(_result); }
        [Route("api/complicationOptions04")]
        [HttpGet]
        public async Task<IActionResult> getGeneral_045() { _result = await _copd.getComplicatieOptie04(); return Ok(_result); }
        [Route("api/complicationOptions05")]
        [HttpGet]
        public async Task<IActionResult> getGeneral_046() { _result = await _copd.getComplicatieOptie05(); return Ok(_result); }
        [Route("api/complicationOptions06")]
        [HttpGet]
        public async Task<IActionResult> getGeneral_047() { _result = await _copd.getComplicatieOptie06(); return Ok(_result); }
        [Route("api/complicationOptions07")]
        [HttpGet]
        public async Task<IActionResult> getGeneral_048() { _result = await _copd.getComplicatieOptie07(); return Ok(_result); }
        [Route("api/complicationOptions08")]
        [HttpGet]
        public async Task<IActionResult> getGeneral_049() { _result = await _copd.getComplicatieOptie08(); return Ok(_result); }
        [Route("api/complicationOptions09")]
        [HttpGet]
        public async Task<IActionResult> getGeneral_050() { _result = await _copd.getComplicatieOptie09(); return Ok(_result); }

        #endregion
        #region <!--aortic surgery -->

        [Route("api/aneurysmType")]
        [HttpGet]
        public async Task<IActionResult> getGeneral_057() { _result = await _copd.getAneurysmType(); return Ok(_result); }
        [Route("api/dissectionOnset")]
        [HttpGet]
        public async Task<IActionResult> getGeneral_058() { _result = await _copd.getDissectionOnset(); return Ok(_result); }
        [Route("api/dissectionType")]
        [HttpGet]
        public async Task<IActionResult> getGeneral_059() { _result = await _copd.getDissectionType(); return Ok(_result); }
        [Route("api/pathology")]
        [HttpGet]
        public async Task<IActionResult> getGeneral_060() { _result = await _copd.getPathology(); return Ok(_result); }
        [Route("api/opIndication")]
        [HttpGet]
        public async Task<IActionResult> getGeneral_061() { _result = await _copd.getOpIndication(); return Ok(_result); }
        [Route("api/optechnique")]
        [HttpGet]
        public async Task<IActionResult> getGeneral_062() { _result = await _copd.getOpTechnique(); return Ok(_result); }
        [Route("api/rangeReplacement")]
        [HttpGet]
        public async Task<IActionResult> getGeneral_063() { _result = await _copd.getRangeReplacement(); return Ok(_result); }
        #endregion
        #region <!--off pump -->

        [Route("api/conversionDetails")]
        [HttpGet]
        public async Task<IActionResult> getGeneral_064() { _result = await _copd.getConversionDetails(); return Ok(_result); }
        [Route("api/strategy")]
        [HttpGet]
        public async Task<IActionResult> getGeneral_065() { _result = await _copd.getStrategy(); return Ok(_result); }
        [Route("api/primaryIncision")]
        [HttpGet]
        public async Task<IActionResult> getGeneral_066() { _result = await _copd.getPrimaryIncision(); return Ok(_result); }
        [Route("api/follow1")]
        [HttpGet]
        public async Task<IActionResult> getGeneral_067() { _result = await _copd.getFollow_1(); return Ok(_result); }
        [Route("api/follow2")]
        [HttpGet]
        public async Task<IActionResult> getGeneral_068() { _result = await _copd.getFollow_2(); return Ok(_result); }
        [Route("api/limaHarvest")]
        [HttpGet]
        public async Task<IActionResult> getGeneral_069() { _result = await _copd.getLimaHarvest(); return Ok(_result); }
        [Route("api/stabilization")]
        [HttpGet]
        public async Task<IActionResult> getGeneral_070() { _result = await _copd.getStabilization(); return Ok(_result); }
        [Route("api/sutureTechnique")]
        [HttpGet]
        public async Task<IActionResult> getGeneral_071() { _result = await _copd.getSutureTechnique(); return Ok(_result); }
        [Route("api/follow3")]
        [HttpGet]
        public async Task<IActionResult> getGeneral_072() { _result = await _copd.getFollow_3(); return Ok(_result); }
        #endregion

       
    }
}