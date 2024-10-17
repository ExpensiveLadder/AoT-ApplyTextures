using Mutagen.Bethesda;
using Mutagen.Bethesda.Synthesis;
using Mutagen.Bethesda.Skyrim;
using nifly;
using Mutagen.Bethesda.Plugins;

using Mutagen.Bethesda.Archives;
using Noggog;

namespace AoTSetTexturesetsFromModel
{
    public class Program
    {
        public static async Task<int> Main(string[] args)
        {
            return await SynthesisPipeline.Instance
                .AddPatch<ISkyrimMod, ISkyrimModGetter>(RunPatch)
                .SetTypicalOpen(GameRelease.SkyrimSE, "YourPatcher.esp")
                .Run(args);
        }

        public readonly static Dictionary<string, Dictionary<string, string>> Overrides = new() {
            {"300ALTDaedricStormCloakCuirassAltAA", new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase) {
                {"textures\\armor\\stormcloaks\\stormcloakscuirass.dds", "300ArmorALTDaedricStormCloakCuirassAltMTS"},
                {"textures\\armor\\stormcloaks\\stormcloakscuirassf.dds", "300ArmorALTDaedricStormCloakCuirassAltFTS"},
            }},
            {"300ALTEbonyStormCloakCuirassAltAA", new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase) {
                {"textures\\armor\\stormcloaks\\stormcloakscuirass.dds", "300ArmorALTEbonyStormCloakCuirassAltMTS"},
                {"textures\\armor\\stormcloaks\\stormcloakscuirassf.dds", "300ArmorALTEbonyStormCloakCuirassAltFTS"},
            }},
            {"300IronStormCloakCuirassAltAA", new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase) {
                {"textures\\armor\\stormcloaks\\stormcloakscuirass.dds", "300ArmorIronStormCloakCuirassAltMTS"},
                {"textures\\armor\\stormcloaks\\stormcloakscuirassf.dds", "300ArmorIronStormCloakCuirassAltFTS"},
            }},
            {"300DaedricStormCloakCuirassAltAA", new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase) {
                {"textures\\armor\\stormcloaks\\stormcloakscuirass.dds", "300ArmorDaedricStormCloakCuirassAltMTS"},
                {"textures\\armor\\stormcloaks\\stormcloakscuirassf.dds", "300ArmorDaedricStormCloakCuirassAltFTS"},
            }},
            {"300EbonyStormCloakCuirassAltAA", new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase) {
                {"textures\\armor\\stormcloaks\\stormcloakscuirass.dds", "300ArmorEbonyStormCloakCuirassAltMTS"},
                {"textures\\armor\\stormcloaks\\stormcloakscuirassf.dds", "300ArmorEbonyStormCloakCuirassAltFTS"},
            }},
            {"300GlassStormCloakCuirassAltAA", new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase) {
                {"textures\\armor\\stormcloaks\\stormcloakscuirass.dds", "300ArmorGlassStormCloakCuirassAltMTS"},
                {"textures\\armor\\stormcloaks\\stormcloakscuirassf.dds", "300ArmorGlassStormCloakCuirassAltFTS"},
            }},
            {"300SilverStormCloakCuirassAltAA", new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase) {
                {"textures\\armor\\stormcloaks\\stormcloakscuirass.dds", "300ArmorSilverStormCloakCuirassAltMTS"},
                {"textures\\armor\\stormcloaks\\stormcloakscuirassf.dds", "300ArmorSilverStormCloakCuirassAltFTS"},
            }},
            {"300SteelStormCloakCuirassAltAA", new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase) {
                {"textures\\armor\\stormcloaks\\stormcloakscuirass.dds", "300ArmorSteelStormCloakCuirassAltMTS"},
                {"textures\\armor\\stormcloaks\\stormcloakscuirassf.dds", "300ArmorSteelStormCloakCuirassAltFTS"},
            }},
            {"300DwarvenStormCloakCuirassAltAA", new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase) {
                {"textures\\armor\\stormcloaks\\stormcloakscuirass.dds", "300ArmorDwarvenStormCloakCuirassAltMTS"},
                {"textures\\armor\\stormcloaks\\stormcloakscuirassf.dds", "300ArmorDwarvenStormCloakCuirassAltFTS"},
            }},
            {"300OrichalcumStormCloakCuirassAltAA", new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase) {
                {"textures\\armor\\stormcloaks\\stormcloakscuirass.dds", "300ArmorOrichalcumStormCloakCuirassAltMTS"},
                {"textures\\armor\\stormcloaks\\stormcloakscuirassf.dds", "300ArmorOrichalcumStormCloakCuirassAltFTS"},
            }},
            {"300MoonstoneStormCloakCuirassAltAA", new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase) {
                {"textures\\armor\\stormcloaks\\stormcloakscuirass.dds", "300ArmorMoonstoneStormCloakCuirassAltMTS"},
                {"textures\\armor\\stormcloaks\\stormcloakscuirassf.dds", "300ArmorMoonstoneStormCloakCuirassAltFTS"},
            }},
                        //TODO: Thalmor
        };

        public readonly static Dictionary<string, string> Textures = new(StringComparer.OrdinalIgnoreCase) {
            {"textures\\weapons\\akaviri\\Bladessword.dds", "300MaterialAkavirSwordTS"},
            {"textures\\weapons\\akaviri\\BladeSheath.dds", "300MaterialAkavirScabbardTS"},
            {"textures\\weapons\\daedric\\daedricaxe.dds", "300MaterialDremoraBattleaxeTS"},
            {"textures\\weapons\\daedric\\daedricbow.dds", "300MaterialDremoraBowTS"},
            {"textures\\weapons\\daedric\\daedricarrow.dds", "300MaterialDremoraArrowTS"},
            {"textures\\weapons\\daedric\\daedrichammer.dds", "300MaterialDremoraWarhammerTS"},
            {"textures\\weapons\\daedric\\daedricmace.dds", "300MaterialDremoraMaceTS"},
            {"textures\\weapons\\daedric\\daedricsword.dds", "300MaterialDremoraSwordTS"},
            {"textures\\weapons\\draugr\\draugrarrow.dds", "300MaterialAncientArrowTS"},
            {"textures\\weapons\\draugr\\draugrbattleaxe.dds", "300MaterialAncientGreataxeTS"},
            {"textures\\weapons\\draugr\\draugrbow.dds", "300MaterialAncientBowTS"},
            {"textures\\weapons\\draugr\\draugrgreatssword.dds", "300MaterialAncientGreatswordTS"},
            {"textures\\weapons\\draugr\\draugrhandaxe.dds", "300MaterialAncientBattleaxeTS"},
            {"textures\\weapons\\draugr\\draugrsword.dds", "300MaterialAncientSwordTS"},
            {"textures\\weapons\\dwarven\\dwarvenarrow.dds", "300MaterialDwemerArrowTS"},
            {"textures\\weapons\\dwarven\\dwarvenbattleaxe.dds", "300MaterialDwemerGreataxeTS"},
            {"textures\\weapons\\dwarven\\dwarvenbow.dds", "300MaterialDwemerBowTS"},
            {"textures\\weapons\\dwarven\\dwarvendagger.dds", "300MaterialDwemerDaggerTS"},
            {"textures\\weapons\\dwarven\\dwarvengreatsword.dds", "300MaterialDwemerGreatswordTS"},
            {"textures\\weapons\\dwarven\\dwarvenhandaxe.dds", "300MaterialDwemerBattleaxeTS"},
            {"textures\\weapons\\dwarven\\dwarvenmace.dds", "300MaterialDwemerMaceTS"},
            {"textures\\weapons\\dwarven\\dwarvenscabbard.dds", "300MaterialDwemerScabbardTS"},
            {"textures\\weapons\\dwarven\\dwarvensword.dds", "300MaterialDwemerSwordTS"},
            {"textures\\weapons\\dwarven\\dwarvenwarhammer.dds", "300MaterialDwemerWarhammerTS"},
            {"textures\\weapons\\ebony\\ebonyarrow.dds", "300MaterialDunmerArrowTS"},
            {"textures\\weapons\\ebony\\ebonybattleaxe.dds", "300MaterialDunmerGreataxeTS"},
            {"textures\\weapons\\ebony\\ebonybow.dds", "300MaterialDunmerBowTS"},
            {"textures\\weapons\\ebony\\ebonydagger.dds", "300MaterialDunmerDaggerTS"},
            {"textures\\weapons\\ebony\\ebonygreatsword.dds", "300MaterialDunmerGreatswordTS"},
            {"textures\\weapons\\ebony\\ebonymace.dds", "300MaterialDunmerMaceTS"},
            {"textures\\weapons\\ebony\\ebonyscabbards.dds", "300MaterialDunmerScabbardTS"},
            {"textures\\weapons\\ebony\\ebonysword.dds", "300MaterialDunmerSwordTS"},
            {"textures\\weapons\\ebony\\ebonywaraxe.dds", "300MaterialDunmerBattleaxeTS"},
            {"textures\\weapons\\ebony\\ebonywarhammer.dds", "300MaterialDunmerWarhammerTS"},
            {"textures\\weapons\\elven\\battleaxe\\elvenbattleaxe.dds", "300MaterialAltmerGreataxeTS"},
            {"textures\\weapons\\elven\\bow\\bow.dds", "300MaterialAltmerBowTS"},
            {"textures\\weapons\\elven\\dagger\\dagger_d.dds", "300MaterialAltmerDaggerTS"},
            {"textures\\weapons\\elven\\greatsword\\greatsword_d.dds", "300MaterialAltmerGreatswordTS"},
            {"textures\\weapons\\elven\\handaxe\\handaxe.dds", "300MaterialAltmerBattleaxeTS"},
            {"textures\\weapons\\elven\\mace\\mace.dds", "300MaterialAltmerMaceTS"},
            {"textures\\weapons\\elven\\scabbard\\scabbard.dds", "300MaterialAltmerScabbardTS"},
            {"textures\\weapons\\elven\\sword\\sword_d.dds", "300MaterialAltmerSwordTS"},
            {"textures\\weapons\\elven\\warhammer\\elvenwarhammer.dds", "300MaterialAltmerWarhammerTS"},
            {"textures\\weapons\\glass\\glassbattleaxe.dds", "300MaterialOrnateGreataxeTS"},
            {"textures\\weapons\\glass\\glassbow.dds", "300MaterialOrnateBowTS"},
            {"textures\\weapons\\glass\\glassdagger.dds", "300MaterialOrnateDaggerTS"},
            {"textures\\weapons\\glass\\glassgreatsword.dds", "300MaterialOrnateGreatswordTS"},
            {"textures\\weapons\\glass\\glasshammer.dds", "300MaterialOrnateWarhammerTS"},
            {"textures\\weapons\\glass\\glasshandaxe.dds", "300MaterialOrnateBattleaxeTS"},
            {"textures\\weapons\\glass\\glassmace.dds", "300MaterialOrnateMaceTS"},
            {"textures\\weapons\\glass\\glasssword.dds", "300MaterialOrnateSwordTS"},
            {"textures\\weapons\\glass\\swordholder.dds", "300MaterialOrnateScabbardTS"},
            {"textures\\weapons\\imperial\\imperialscabbard.dds", "300MaterialImperialScabbardTS"},
            {"textures\\weapons\\imperial\\imperialsword.dds", "300MaterialImperialSwordTS"},
            {"textures\\weapons\\iron\\ironbattleaxe.dds", "300MaterialBasicGreataxeTS"},
            {"textures\\weapons\\iron\\ironclaymore.dds", "300MaterialBasicGreatswordTS"},
            {"textures\\weapons\\iron\\irondagger.dds", "300MaterialBasicDaggerTS"},
            {"textures\\weapons\\iron\\ironlongsword.dds", "300MaterialBasicSwordTS"},
            {"textures\\weapons\\iron\\ironmace.dds", "300MaterialBasicMaceTS"},
            {"textures\\weapons\\iron\\ironscabbards.dds", "300MaterialBasicScabbardTS"},
            {"textures\\weapons\\iron\\ironwaraxe.dds", "300MaterialBasicBattleaxeTS"},
            {"textures\\weapons\\iron\\ironwarhammer.dds", "300MaterialBasicWarhammerTS"},
            {"textures\\weapons\\orcish\\orcishbattleaxe.dds", "300MaterialOrcishGreataxeTS"},
            {"textures\\weapons\\orcish\\orcishbow.dds", "300MaterialOrcishBowTS"},
            {"textures\\weapons\\orcish\\orcishdagger.dds", "300MaterialOrcishDaggerTS"},
            {"textures\\weapons\\orcish\\orcishgreatsword.dds", "300MaterialOrcishGreatswordTS"},
            {"textures\\weapons\\orcish\\orcishhandaxe.dds", "300MaterialOrcishBattleaxeTS"},
            {"textures\\weapons\\orcish\\orcishmace.dds", "300MaterialOrcishMaceTS"},
            {"textures\\weapons\\orcish\\orcishscabbards.dds", "300MaterialOrcishScabbardTS"},
            {"textures\\weapons\\orcish\\orcishsword.dds", "300MaterialOrcishSwordTS"},
            {"textures\\weapons\\orcish\\orcishwarhammer.dds", "300MaterialOrcishWarhammerTS"},
            {"textures\\weapons\\scimitar\\scimitar.dds", "300MaterialRedguardSwordTS"},
            {"textures\\weapons\\silver\\silversword.dds", "300MaterialBretonSwordTS"},
            {"textures\\weapons\\steel\\steelbattleaxe.dds", "300MaterialNordicGreataxeTS"},
            {"textures\\weapons\\steel\\steelbow.dds", "300MaterialNordicBowTS"},
            {"textures\\weapons\\steel\\steelclaymore.dds", "300MaterialNordicGreatswordTS"},
            {"textures\\weapons\\steel\\steeldagger.dds", "300MaterialNordicDaggerTS"},
            {"textures\\weapons\\steel\\steelmace.dds", "300MaterialNordicMaceTS"},
            {"textures\\weapons\\steel\\steelscabbards.dds", "300MaterialNordicScabbardTS"},
            {"textures\\weapons\\steel\\steelsword.dds", "300MaterialNordicSwordTS"},
            {"textures\\weapons\\steel\\steelwaraxe.dds", "300MaterialNordicBattleaxeTS"},
            {"textures\\weapons\\steel\\steelwarhammer.dds", "300MaterialNordicWarhammerTS"},
            {"textures\\dlc01\\weapons\\crossbow\\bolt.dds", "300DLC1MaterialDawnguardBoltTS"},
            {"textures\\dlc01\\weapons\\crossbow\\crossbow.dds", "300DLC1MaterialCrossBowTS"},
            {"textures\\dlc02\\weapons\\nordic\\axe_small\\axe_small_d.dds", "300DLC2MaterialSkaalBattleaxeTS"},
            {"textures\\dlc02\\weapons\\nordic\\axe_tall\\axetall_final_d.dds", "300DLC2MaterialSkaalGreataxeTS"},
            {"textures\\dlc02\\weapons\\nordic\\bow_nordic\\bow_nordic_d.dds", "300DLC2MaterialSkaalBowTS"},
            {"textures\\dlc02\\weapons\\nordic\\dagger_nordic\\dagger_nordic_01_d.dds", "300DLC2MaterialSkaalDaggerTS"},
            {"textures\\dlc02\\weapons\\nordic\\hammer_nordic\\hammer_nordic_d.dds", "300DLC2MaterialSkaalWarhammerTS"},
            {"textures\\dlc02\\weapons\\nordic\\mace_nordic\\mace_nordic_d.dds", "300DLC2MaterialSkaalMaceTS"},
            {"textures\\dlc02\\weapons\\nordic\\sword_nordic\\sword_nordic_01_d.dds", "300DLC2MaterialSkaalSwordTS"},
            {"textures\\dlc02\\weapons\\nordic\\sword_tall\\2handed_sword_nordic_d.dds", "300DLC2MaterialSkaalGreatswordTS"},
            {"textures\\dlc01\\weapons\\dwarvencrossbow\\dwarvenbolt.dds", "300DLC1MaterialDwemerBoltTS"},
            {"textures\\dlc01\\weapons\\dwarvencrossbow\\dwarvencrossbow.dds", "300DLC1MaterialDwemerCrossBowTS"},
            {"textures\\dlc01\\weapons\\hunter hammer\\dawnguardhammer.dds", "300DLC1MaterialDawnguardWarhammerTS"},
            {"textures\\dlc01\\weapons\\hunter axe\\hunteraxe.dds", "300DLC1MaterialDawnguardBattleaxeTS"},
            {"textures\\weapons\\iron\\ironbow.dds", "300MaterialImperialBowTS"},
            {"textures\\weapons\\300iron\\redguardsword.dds", "300MaterialRedguardSwordTS"},
            {"textures\\dlc02\\weapons\\hammer\\Hammer_d.dds", "300MaterialImperialWarhammerTS"},
            {"textures\\weapons\\wooden\\bow.dds", "300MaterialBasicBowTS"},
            {"textures\\weapons\\300daedric\\akivirigreatsword.dds", "300MaterialAkavirGreatswordTS"},
            {"textures\\weapons\\300iron\\basicscabbard.dds", "300MaterialBasicScabbardTS"},
                      
            {"textures\\armor\\blades\\bladesarmor.dds", "300ArmorMaterialBladesCuirassTS"},
            {"textures\\armor\\blades\\bladesboots.dds", "300ArmorMaterialBladesBootsTS"},
            {"textures\\armor\\blades\\bladeshelmet.dds", "300ArmorMaterialBladesHelmetTS"},
            {"textures\\armor\\blades\\bladesgauntlet.dds", "300ArmorMaterialBladesGauntletsTS"},
            {"textures\\weapons\\blades\\shield.dds", "300ArmorMaterialBladesShieldTS"},
            {"textures\\armor\\daedric\\daedricarmor.dds", "300ArmorMaterialDremoraCuirassTS"},
            {"textures\\armor\\daedric\\daedricboots.dds", "300ArmorMaterialDremoraBootsTS"},
            {"textures\\armor\\daedric\\daedricgloves.dds", "300ArmorMaterialDremoraGauntletsTS"},
            {"textures\\armor\\daedric\\daedrichelmet.dds", "300ArmorMaterialDremoraHelmetTS"},
            {"textures\\armor\\daedric\\daedricshield.dds", "300ArmorMaterialDremoraShieldTS"},
            {"textures\\armor\\draugr\\femaledraugrarmor.dds", "300ArmorMaterialAncientCuirassFTS"},
            //{"textures\\armor\\draugr\\femaledraugrboots.dds", "300ArmorMaterialAncientBootsFTS"},
            {"textures\\armor\\draugr\\maledraugrboots.dds", "300ArmorMaterialAncientBootsTS"},
            {"textures\\armor\\draugr\\femaledraugrgauntlets.dds", "300ArmorMaterialAncientGauntletsFTS"},
            {"textures\\armor\\draugr\\femaledraugrhelmet.dds", "300ArmorMaterialAncientHelmetFTS"},
            {"textures\\armor\\draugr\\maledraugrarmor.dds", "300ArmorMaterialAncientCuirassMTS"},
            {"textures\\armor\\draugr\\maledraugrgauntlets.dds", "300ArmorMaterialAncientGauntletsMTS"},
            {"textures\\armor\\draugr\\maledraugrhelmet.dds", "300ArmorMaterialAncientHelmetMTS"},
            {"textures\\armor\\dwarven\\dwarvenshield.dds", "300ArmorMaterialDwemerShieldTS"},
            {"textures\\armor\\dwarven\\f\\dwarvenarmorf.dds", "300ArmorMaterialDwemerCuirassFTS"},
            {"textures\\armor\\dwarven\\f\\dwarvenhelmetf.dds", "300ArmorMaterialDwemerHelmetFTS"},
            {"textures\\armor\\dwarven\\m\\dwarvenarmor.dds", "300ArmorMaterialDwemerCuirassMTS"},
            {"textures\\armor\\dwarven\\m\\dwarvenboots.dds", "300ArmorMaterialDwemerBootsTS"},
            {"textures\\armor\\dwarven\\m\\dwarvengauntlets.dds", "300ArmorMaterialDwemerGauntletsTS"},
            {"textures\\armor\\dwarven\\m\\dwarvenhelmetmale.dds", "300ArmorMaterialDwemerHelmetMTS"},
            {"textures\\armor\\ebonyarmor\\f\\ebonyarmorbodyf.dds", "300ArmorMaterialDunmerCuirassFTS"},
            {"textures\\armor\\ebonyarmor\\f\\ebonyarmorbootsf.dds", "300ArmorMaterialDunmerBootsFTS"},
            {"textures\\armor\\ebonyarmor\\f\\ebonyarmorglovesf.dds", "300ArmorMaterialDunmerGauntletsFTS"},
            {"textures\\armor\\ebonyarmor\\f\\ebonyarmorhelmetf.dds", "300ArmorMaterialDunmerHelmetFTS"},
            {"textures\\armor\\ebonyarmor\\m\\ebonyarmorbodym.dds", "300ArmorMaterialDunmerCuirassMTS"},
            {"textures\\armor\\ebonyarmor\\m\\ebonyarmorbootsm.dds", "300ArmorMaterialDunmerBootsMTS"},
            {"textures\\armor\\ebonyarmor\\m\\ebonyarmorglovesm.dds", "300ArmorMaterialDunmerGauntletsMTS"},
            {"textures\\armor\\ebonyarmor\\m\\ebonyarmorhelmetm.dds", "300ArmorMaterialDunmerHelmetMTS"},
            {"textures\\weapons\\ebony\\ebony shield_d.dds", "300ArmorMaterialDunmerShieldTS"},
            {"textures\\armor\\ebonymail\\f\\ebonymailbodyf.dds", "300ArmorMaterialDunmerMailCuirassFTS"},
            {"textures\\armor\\ebonymail\\m\\ebonymailbodym.dds", "300ArmorMaterialDunmerMailCuirassMTS"},
            {"textures\\armor\\elven\\f\\cuirass.dds", "300ArmorMaterialAltmerCuirassFTS"},
            {"textures\\armor\\elven\\m\\boots_d.dds", "300ArmorMaterialAltmerBootsTS"},
            {"textures\\armor\\elven\\m\\cuirass_d.dds", "300ArmorMaterialAltmerCuirassMTS"},
            {"textures\\armor\\elven\\m\\gauntlets_d.dds", "300ArmorMaterialAltmerGauntletsTS"},
            {"textures\\armor\\elven\\m\\helmet_d.dds", "300ArmorMaterialAltmerHelmetTS"},
            {"textures\\weapons\\elven\\shield\\elvenshield_d.dds", "300ArmorMaterialAltmerShieldTS"},
            {"textures\\armor\\glass\\f\\curiass.dds", "300ArmorMaterialOrnateCuirassFTS"},
            {"textures\\armor\\glass\\m\\boots.dds", "300ArmorMaterialOrnateBootsTS"},
            {"textures\\armor\\glass\\m\\curiass.dds", "300ArmorMaterialOrnateCuirassMTS"},
            {"textures\\armor\\glass\\m\\gauntlet.dds", "300ArmorMaterialOrnateGauntletsTS"},
            {"textures\\armor\\glass\\m\\helmet.dds", "300ArmorMaterialOrnateHelmetTS"},
            {"textures\\armor\\glass\\shield\\shield.dds", "300ArmorMaterialOrnateShieldTS"},
            {"textures\\armor\\hide\\f\\cuirasslight.dds", "300ArmorMaterialHideCuirassFTS"},
            {"textures\\armor\\hide\\m\\cuirasslight.dds", "300ArmorMaterialHideCuirassMTS"},
            {"textures\\armor\\hide\\m\\bootslight.dds", "300ArmorMaterialHideBootsTS"},
            {"textures\\armor\\hide\\m\\helmetlight.dds", "300ArmorMaterialHideHelmetTS"},
            {"textures\\armor\\hide\\m\\gauntletslight.dds", "300ArmorMaterialHideGauntletsTS"},
            {"textures\\armor\\hide\\hideshield.dds", "300ArmorMaterialHideShieldTS"},
            {"textures\\armor\\hide\\f\\cuirassheavy.dds", "300ArmorMaterialHideCuirass02FTS"},
            {"textures\\armor\\hide\\m\\cuirassheavy.dds", "300ArmorMaterialHideCuirass02MTS"},
            {"textures\\armor\\hide\\m\\bootsheavy.dds", "300ArmorMaterialHideBoots01TS"},
            {"textures\\armor\\hide\\m\\gauntletsheavy.dds", "300ArmorMaterialHideGauntlets01TS"},
            {"textures\\armor\\hide\\m\\helmetheavy.dds", "300ArmorMaterialHideHelmet01TS"},
            {"textures\\armor\\imperial\\f\\cuirasslight.dds", "300ArmorMaterialImperialLightCuirassFTS"},
            {"textures\\armor\\imperial\\m\\cuirasstrooper.dds", "300ArmorMaterialImperialLightCuirassMTS"},
            {"textures\\armor\\imperial\\m\\bootslight.dds", "300ArmorMaterialImperialLightBootsTS"},
            {"textures\\armor\\imperial\\m\\gauntletslight.dds", "300ArmorMaterialImperialLightGauntletsTS"},
            {"textures\\armor\\imperial\\m\\helmetlight.dds", "300ArmorMaterialImperialLightHelmetTS"},
            {"textures\\armor\\imperial\\f\\cuirassheavy.dds", "300ArmorMaterialImperialCuirassFTS"},
            {"textures\\armor\\imperial\\m\\cuirass.dds", "300ArmorMaterialImperialCuirassMTS"},
            {"textures\\armor\\imperial\\helmetfull.dds", "300ArmorMaterialImperialHelmetCWTS"},
            {"textures\\armor\\imperial\\m\\boots.dds", "300ArmorMaterialImperialBootsTS"},
            {"textures\\armor\\imperial\\m\\gauntlets.dds", "300ArmorMaterialImperialGauntletsTS"},
            {"textures\\armor\\imperial\\m\\helmet.dds", "300ArmorMaterialImperialHelmetTS"},
            {"textures\\armor\\imperial\\m\\helmetmedium.dds", "300ArmorMaterialImperialHelmetMediumTS"},
            {"textures\\armor\\imperial\\imperialshield.dds", "300ArmorMaterialImperialShieldTS"},
            {"textures\\armor\\imperial\\imperialshieldtrooper.dds", "300ArmorMaterialImperialLightShieldTS"},
            {"textures\\armor\\iron\\f\\cuirassplate.dds", "300ArmorMaterialBasicCuirassFTS"},
            {"textures\\armor\\iron\\m\\cuirassplate.dds", "300ArmorMaterialBasicCuirassMTS"},
            {"textures\\armor\\iron\\m\\bootsplate.dds", "300ArmorMaterialBasicBootsTS"},
            {"textures\\armor\\iron\\m\\gauntletsplate.dds", "300ArmorMaterialBasicGauntletsTS"},
            {"textures\\armor\\iron\\m\\helmetplate.dds", "300ArmorMaterialBasicHelmetFTS"},
            {"textures\\armor\\iron\\m\\helmetplate01.dds", "300ArmorMaterialBasicHelmetMTS"},
            {"textures\\armor\\iron\\shield.dds", "300ArmorMaterialBasicShieldTS"},
            {"textures\\armor\\iron\\ironshieldheavy.dds", "300ArmorMaterialBasicShieldHeavyTS"},
            {"textures\\armor\\nordplate\\nordplatebootsf.dds", "300ArmorMaterialNordicPlateBootsTS"},
            {"textures\\armor\\nordplate\\nordplatef.dds", "300ArmorMaterialNordicPlateCuirassFTS"},
            {"textures\\armor\\nordplate\\nordplateglovesf.dds", "300ArmorMaterialNordicPlateGauntletsTS"},
            {"textures\\armor\\nordplate\\nordplatehelmf.dds", "300ArmorMaterialNordicPlateHelmetTS"},
            {"textures\\armor\\nordplate\\nordplatem.dds", "300ArmorMaterialNordicPlateCuirassMTS"},
            {"textures\\armor\\orcish\\orc_armor_female_body_d.dds", "300ArmorMaterialOrcishCuirassFTS"},
            {"textures\\armor\\orcish\\orc_armor_female_boot_d.dds", "300ArmorMaterialOrcishBootsFTS"},
            {"textures\\armor\\orcish\\orc_armor_female_glove_d.dds", "300ArmorMaterialOrcishGauntletsFTS"},
            {"textures\\armor\\orcish\\orc_armor_female_helmet_d.dds", "300ArmorMaterialOrcishCuirassFTS"},
            {"textures\\armor\\orcish\\orc_armor_male_body_d.dds", "300ArmorMaterialOrcishCuirassMTS"},
            {"textures\\armor\\orcish\\orc_armor_male_boot_d.dds", "300ArmorMaterialOrcishBootsMTS"},
            {"textures\\armor\\orcish\\orc_armor_male_glove_d.dds", "300ArmorMaterialOrcishGauntletsMTS"},
            {"textures\\armor\\orcish\\orc_armor_male_helmet_d.dds", "300ArmorMaterialOrcishCuirassMTS"},
            {"textures\\armor\\orcish\\orcshield.dds", "300ArmorMaterialOrcishShieldTS"},
            {"textures\\armor\\sonsoftalos\\sonsoftalosbodyf.dds", "300ArmorMaterialStormCloakBearCuirassFTS"},
            {"textures\\armor\\sonsoftalos\\sonsoftalosbodym.dds", "300ArmorMaterialStormCloakBearCuirassMTS"},
            {"textures\\armor\\sonsoftalos\\sonsoftalosbootsm.dds", "300ArmorMaterialStormCloakBearBootsTS"},
            {"textures\\armor\\sonsoftalos\\sonsoftaloscapm.dds", "300ArmorMaterialStormCloakBearHelmetTS"},
            {"textures\\armor\\sonsoftalos\\sonsoftalosglovesm.dds", "300ArmorMaterialStormCloakBearGauntletsTS"},
            {"textures\\armor\\steel\\m\\steelarmor.dds", "300ArmorMaterialNordicCuirassTS"},
            {"textures\\armor\\steel\\m\\steelboot.dds", "300ArmorMaterialNordicBootsTS"},
            //{"textures\\armor\\steel\\m\\steelboots.dds", ""}, ?
            {"textures\\armor\\steel\\m\\steelgauntlets.dds", "300ArmorMaterialNordicGauntletsTS"},
            {"textures\\armor\\steel\\m\\steelhelmetheavy.dds", "300ArmorMaterialNordicBHelmetTS"},
            {"textures\\armor\\steel\\m\\steelhelmetlite.dds", "300ArmorMaterialNordicHelmetTS"},
            {"textures\\armor\\steel\\steelshield.dds", "300ArmorMaterialNordicShieldTS"},
            {"textures\\armor\\stormcloaks\\stormcloakscuirass.dds", "300ArmorMaterialStormCloakCuirassMTS"},
            {"textures\\armor\\stormcloaks\\stormcloakscuirassf.dds", "300ArmorMaterialStormCloakCuirassFTS"},
            //{"textures\\armor\\stormcloaks\\stormcloakscuirass.dds", "300ArmorMaterialStormCloakCuirassAltMTS"},
            //{"textures\\armor\\stormcloaks\\stormcloakscuirassf.dds", "300ArmorMaterialStormCloakCuirassAltFTS"},
            {"textures\\armor\\stormcloaks\\stormcloaksboots.dds", "300ArmorMaterialStormCloakBootsTS"},
            {"textures\\armor\\stormcloaks\\stormcloaksgloves.dds", "300ArmorMaterialStormCloakGauntletsTS"},
            {"textures\\armor\\stormcloaks\\stormcloakshelm.dds", "300ArmorMaterialStormCloakHelmetTS"},
            {"textures\\armor\\stormcloaks\\stormcloaksshield.dds", "300ArmorMaterialStormCloakShieldTS"},
            {"Textures\\Armor\\300\\DaedricALT\\Stormcloak\\stormcloaksshield.dds", "300ArmorMaterialStormCloakShieldTS"},
            {"textures\\armor\\studded\\studdedarmor_male_body_d.dds", "300ArmorMaterialStuddedLeatherCuirassMTS"},
            {"textures\\armor\\studded\\studdedarmor_male_boot_d.dds", "300ArmorMaterialStuddedLeatherBootsMTS"},
            {"textures\\armor\\studded\\studdedarmor_male_helmet_d.dds", "300ArmorMaterialStuddedLeatherHelmetMTS"},
            {"textures\\armor\\studded\\studdedarmorfem01_body_d.dds", "300ArmorMaterialStuddedLeatherCuirassFTS"},
            {"textures\\armor\\studded\\studdedarmorfem01_boot_d.dds", "300ArmorMaterialStuddedLeatherBootsFTS"},
            {"textures\\armor\\studded\\studdedarmorfem01_helmet_d.dds", "300ArmorMaterialStuddedLeatherHelmetFTS"},
            {"textures\\armor\\wolf\\wolfarmorbootsm.dds", "300ArmorMaterialCompanionsBootsTS"},
            {"textures\\armor\\wolf\\wolfarmorf.dds", "300ArmorMaterialCompanionsCuirassFTS"},
            {"textures\\armor\\wolf\\wolfarmorglovesm.dds", "300ArmorMaterialCompanionsGauntletsTS"},
            {"textures\\armor\\wolf\\wolfarmorhatm.dds", "300ArmorMaterialCompanionsHelmetTS"},
            {"textures\\armor\\wolf\\wolfarmorm.dds", "300ArmorMaterialCompanionsCuirassMTS"},
            {"textures\\armor\\thievesguild\\f\\thievesguildarmorclothesf.dds", "300ArmorMaterialLeatherCuirassFTS"},
            {"textures\\armor\\thievesguild\\f\\thievesguildarmorclothesfv02.dds", "300ArmorMaterialLeatherCuirassFTS"},
            //{"textures\\armor\\thievesguild\\f\\thievesguildarmorclothesfvleader.dds", ""},
            {"textures\\armor\\thievesguild\\m\\thievesguildarmortorsom.dds", "300ArmorMaterialLeatherCuirassMTS"},
            {"textures\\armor\\thievesguild\\m\\thievesguildarmortorsomv2.dds", "300ArmorMaterialLeatherCuirassMTS"},
            //{"textures\\armor\\thievesguild\\m\\thievesguildarmortorsomleader.dds", ""},
            {"textures\\armor\\thievesguild\\m\\thievesguildarmorcapm.dds", "300ArmorMaterialLeatherHelmetTS"},
            {"textures\\armor\\thievesguild\\m\\thievesguildarmorcapmv2.dds", "300ArmorMaterialLeatherHelmetTS"},
            {"textures\\armor\\thievesguild\\m\\thievesguildarmorcapmv3.dds", "300ArmorMaterialLeatherHelmetAltTS"},
            //{"textures\\armor\\thievesguild\\m\\thievesguildarmorcapmleader.dds", ""},
            {"textures\\armor\\thievesguild\\m\\thievesguildarmorglovesm.dds", "300ArmorMaterialLeatherGauntletsTS"},
            {"textures\\armor\\thievesguild\\m\\thievesguildarmorglovesmv2.dds", "300ArmorMaterialLeatherGauntletsTS"},
            //{"textures\\armor\\thievesguild\\m\\thievesguildarmorglovesmleader.dds", ""},
            {"textures\\armor\\thievesguild\\m\\thievesguildarmorshoesm.dds", "300ArmorMaterialLeatherBootsTS"},
            {"textures\\armor\\thievesguild\\m\\thievesguildarmorshoesmv2.dds", "300ArmorMaterialLeatherBootsTS"},
            //{"textures\\armor\\thievesguild\\m\\thievesguildarmorshoesmleader.dds", ""},
            {"textures\\dlc01\\armor\\dawnguard\\dawnguardbody1_d.dds", "300DLC1ArmorMaterialDawnguardCuirassTS"},
            {"textures\\dlc01\\armor\\dawnguard\\dawnguardbody2_d.dds", "300DLC1ArmorMaterialDawnguardCuirassTS"},
            {"textures\\dlc01\\armor\\dawnguard\\dawnguardbody3_d.dds", "300DLC1ArmorMaterialDawnguardCuirassTS"},
            {"textures\\dlc01\\armor\\dawnguard\\dawnguardbody4_d.dds", "300DLC1ArmorMaterialDawnguardCuirassTS"},
            {"textures\\dlc01\\armor\\dawnguard\\dawnguardbody5_d.dds", "300DLC1ArmorMaterialDawnguardCuirassTS"},
            {"textures\\dlc01\\armor\\dawnguard\\dawnguardboots1_d.dds", "300DLC1ArmorMaterialDawnguardBootsTS"},
            {"textures\\dlc01\\armor\\dawnguard\\dawnguardgloves1_d.dds", "300DLC1ArmorMaterialDawnguardGauntletsTS"},
            {"textures\\dlc01\\armor\\dawnguard\\dawnguardhelmet_d.dds", "300DLC1ArmorMaterialDawnguardHelmetTS"},
            {"textures\\dlc01\\armor\\dawnguard\\dawnguardhelmetfull_d.dds", "300DLC1ArmorMaterialDawnguardHelmetFullTS"},
            {"textures\\dlc01\\armor\\dawnguard\\dgshield_d.dds", "300DLC1ArmorMaterialDawnguardShieldTS"},
            {"textures\\dlc02\\armor\\nordiccarved\\nordiccarvedbootsm.dds", "300DLC2ArmorMaterialSkaalBootsTS"},
            {"textures\\dlc02\\armor\\nordiccarved\\nordiccarvedcuirassf.dds", "300DLC2ArmorMaterialSkaalCuirassFTS"},
            {"textures\\dlc02\\armor\\nordiccarved\\nordiccarvedcuirassm.dds", "300DLC2ArmorMaterialSkaalCuirassMTS"},
            {"textures\\dlc02\\armor\\nordiccarved\\nordiccarvedglovesm.dds", "300DLC2ArmorMaterialSkaalGauntletsTS"},
            {"textures\\dlc02\\armor\\nordiccarved\\nordiccarvedhelmetm.dds", "300DLC2ArmorMaterialSkaalHelmetTS"},
            {"textures\\dlc02\\armor\\nordicshield\\nordicshield.dds", "300DLC2ArmorMaterialSkaalShieldTS"},
            {"textures\\dlc01\\clothes\\vampire\\boots.dds", "300DLC1ArmorMaterialVampireBootsTS"},
            {"textures\\dlc01\\clothes\\vampire\\gloves.dds", "300DLC1ArmorMaterialVampireGauntletsTS"},
            {"textures\\dlc01\\clothes\\vampire\\robes.dds", "300DLC1ArmorMaterialVampireCuirassMTS"},
            {"textures\\dlc01\\clothes\\vampire\\robes_alt.dds", "300DLC1ArmorMaterialVampireCuirassAlternateMTS"},
            {"textures\\dlc01\\clothes\\vampire\\robes_alt_v2.dds", "300DLC1ArmorMaterialVampireCuirassAlternateMTS"},
            {"textures\\dlc01\\clothes\\vampire\\robes_alt_v3.dds", "300DLC1ArmorMaterialVampireCuirassAlternateMTS"},
            {"textures\\dlc01\\clothes\\vampire\\robesf.dds", "300DLC1ArmorMaterialVampireCuirassFTS"},
            {"textures\\dlc01\\clothes\\vampire\\robesf_alt.dds", "300DLC1ArmorMaterialVampireCuirassAlternateFTS"},
            {"textures\\dlc01\\clothes\\vampire\\robesf_alt_v2.dds", "300DLC1ArmorMaterialVampireCuirassAlternateFTS"},
            {"textures\\dlc01\\clothes\\vampire\\robesf_alt_v3.dds", "300DLC1ArmorMaterialVampireCuirassAlternateFTS"},
        };


        public static bool GetMaterial(string editorID, out string material)
        {

            if (editorID.Contains("Iron"))
            {
                material = "Iron";
            }
            else if (editorID.Contains("Steel"))
            {
                material = "Steel";
            }
            else if (editorID.Contains("Orichalcum"))
            {
                material = "Orichalcum";
            }
            else if (editorID.Contains("Moonstone"))
            {
                material = "Moonstone";
            }
            else if (editorID.Contains("Silver"))
            {
                material = "Silver";
            }
            else if (editorID.Contains("Glass") || editorID.Contains("Malachite"))
            {
                material = "Glass";
            }
            else if (editorID.Contains("ALTEbony"))
            {
                material = "ALTEbony";
            }
            else if (editorID.Contains("ALTDaedric"))
            {
                material = "ALTDaedric";
            }
            else if (editorID.Contains("Ebony"))
            {
                material = "Ebony";
            }
            else if (editorID.Contains("Daedric"))
            {
                material = "Daedric";
            }
            else if (editorID.Contains("Dwarven"))
            {
                material = "Dwarven";
            }
            else
            {
                material = "";
                return false;
            }
            if (editorID.Contains("Mag"))
            {
                if (editorID.Contains("Flame"))
                {
                    material = "MagFlame" + material;
                }
                else if (editorID.Contains("Frost") || editorID.Contains("Shard"))
                {
                    material = "MagFrost" + material;
                }
                else if (editorID.Contains("Shock") || editorID.Contains("Storm"))
                {
                    material = "MagShock" + material;
                }
            }
            return true;
        }

        public static bool TryGetFileFromArchive(List<IArchiveReader> archives, string path, out NifFile niffile)
        {
            niffile = new();
            foreach (var archive in archives) {
                foreach(var file in archive.Files)
                {
                    if (file.Path.Equals(path, StringComparison.OrdinalIgnoreCase))
                    {
                        niffile = new(new vectoruchar(file.GetBytes()));
                        return true;
                    }
                }
            }
            return false;
        }

        /*
        public static NifFile GetFileFromArchive(List<IArchiveReader> archives, string path)
        {
            foreach (var archive in archives)
            {
                Parallel.ForEach(archive.Files, file =>
                {
                    if (file.Path.Equals(path, StringComparison.OrdinalIgnoreCase))
                    {
                        
                        return new(new vectoruchar(file.GetBytes()));
                        break;

                         true;
                    }
                });
            }
            return false;
        }
        */


        public static void RunPatch(IPatcherState<ISkyrimMod, ISkyrimModGetter> state)
        {
            //Your code here!

            bool verboseLogging = false;

            var archives = Archive.GetApplicableArchivePaths(state.GameRelease, state.DataFolderPath);
            List<IArchiveReader> archivereaders = [];
            foreach (var mod in state.LoadOrder.Reverse())
            {
                foreach (var archive in archives)
                {
                    if (Archive.IsApplicable(state.GameRelease, mod.Key, archive.Name))
                    {
                        //Console.WriteLine("File: " + archive + " is applicable to: " + mod.Key);
                        archivereaders.Add(Archive.CreateReader(state.GameRelease, archive));
                    }
                }
            }

            foreach (var weaponGetter in state.LoadOrder.PriorityOrder.Weapon().WinningOverrides())
            {
                var weapon = weaponGetter.DeepCopy();
                if (weapon.EditorID == null || weapon.Model == null || !weapon.Template.IsNull || weapon.EditorID.StartsWith("3001") || !(weapon.EditorID.StartsWith("300") || weapon.EditorID.StartsWith("400"))) continue;

                if (!GetMaterial(weapon.EditorID, out var material))
                {
                    Console.WriteLine("Warning: Could not find material for weapon: " + weapon.EditorID);
                    continue;
                }

                var relativepath = weapon.Model.File;
                var modelPath = state.DataFolderPath + "\\meshes\\" + relativepath;
                NifFile nif = new();
                if (File.Exists(modelPath))
                {
                    Console.WriteLine("Found loose mesh for record: " + weapon.EditorID + ": " + relativepath);
                    nif.Load(modelPath);
                }
                else
                {
                    if (TryGetFileFromArchive(archivereaders, "meshes\\" + relativepath, out var foundnif)) {
                        Console.WriteLine("Found mesh in bsa for record: " + weapon.EditorID + ": " + relativepath);
                        nif = foundnif;
                    } else
                    {
                        Console.WriteLine("ERROR: Could not find model for record: " + weapon.EditorID + ": " + relativepath);
                        continue;
                    }
                }

                weapon.Model.AlternateTextures = [];

                bool foundreplacement = false;
                var shapes = nif.GetShapes();
                foreach (var shape in shapes)
                {
                    var texurepath = nif.GetTexturePathByIndex(shape, 0);
                    if (verboseLogging) Console.WriteLine(texurepath);

                    if (Textures.TryGetValue(texurepath, out var value))
                    {
                        Console.WriteLine("Found texture replacement: " + value.Replace("Material", material.ToString()) + ": " + texurepath);
                        var index = shapes.IndexOf(shape);
                        weapon.Model.AlternateTextures.Add(new AlternateTexture()
                        {
                            Name = nif.GetShapeNames()[index],
                            Index = index,
                            NewTexture = state.LinkCache.Resolve<ITextureSetGetter>(value.Replace("Material", material.ToString())).ToLink()
                        });
                        foundreplacement = true;
                    }
                }
                if (!foundreplacement) Console.WriteLine("Warning: Could not find texture replacements for: " + weapon.EditorID);

                var firstpersonmodel = weapon.FirstPersonModel.Resolve(state.LinkCache).DeepCopy();

                firstpersonmodel.Model = weapon.Model;

                state.PatchMod.Statics.Set(firstpersonmodel);
                state.PatchMod.Weapons.Set(weapon);
            }

            foreach (var armoraddonGetter in state.LoadOrder.PriorityOrder.ArmorAddon().WinningOverrides())
            {
                var armoraddon = armoraddonGetter.DeepCopy();
                if (armoraddon.EditorID == null || armoraddon.EditorID.StartsWith("3001") || !(armoraddon.EditorID.StartsWith("300") || armoraddon.EditorID.StartsWith("400"))) continue;

                if (!GetMaterial(armoraddon.EditorID, out var material))
                {
                    Console.WriteLine("Warning: Could not find material for weapon: " + armoraddon.EditorID);
                    continue;
                }

                if (armoraddon.FirstPersonModel != null)
                {
                    foreach (var model in armoraddon.FirstPersonModel) {
                        if (model == null) continue;

                        var relativepath = model.File;
                        var modelPath = state.DataFolderPath + "\\meshes\\" + relativepath;
                        NifFile nif = new();
                        if (File.Exists(modelPath))
                        {
                            Console.WriteLine("Found loose mesh for record: " + armoraddon.EditorID + ": " + relativepath);
                            nif.Load(modelPath);
                        }
                        else
                        {
                            if (TryGetFileFromArchive(archivereaders, "meshes\\" + relativepath, out var foundnif))
                            {
                                Console.WriteLine("Found mesh in bsa for record: " + armoraddon.EditorID + ": " + relativepath);
                                nif = foundnif;
                            }
                            else
                            {
                                Console.WriteLine("ERROR: Could not find model for record: " + armoraddon.EditorID + ": " + relativepath);
                                continue;
                            }
                        }

                        model.AlternateTextures = [];

                        bool foundreplacement = false;
                        var shapes = nif.GetShapes();
                        foreach (var shape in shapes)
                        {
                            var texurepath = nif.GetTexturePathByIndex(shape, 0);
                            if (verboseLogging) Console.WriteLine(texurepath);

                            var index = shapes.IndexOf(shape);
                            if (Overrides.TryGetValue(armoraddon.EditorID, out var overrides)) {
                                if (overrides.TryGetValue(texurepath, out var overridevalue)) {
                                    Console.WriteLine("Found texture override: " + overridevalue + ": " + texurepath);
                                    model.AlternateTextures.Add(new AlternateTexture()
                                    {
                                        Name = nif.GetShapeNames()[index],
                                        Index = index,
                                        NewTexture = state.LinkCache.Resolve<ITextureSetGetter>(overridevalue).ToLink()
                                    });
                                    foundreplacement = true;
                                    continue;
                                }
                            }
                            if (Textures.TryGetValue(texurepath, out var value))
                            {
                                string textureset = value.Replace("Material", material.ToString());
                                Console.WriteLine("Found texture replacement: " + textureset + ": " + texurepath);
                                IFormLink<ITextureSetGetter> newtexture;
                                if (state.LinkCache.TryResolve<ITextureSetGetter>(textureset, out var foundtexture))
                                {
                                    newtexture = foundtexture.ToLink();
                                }
                                else
                                {
                                    if (material == "ALTEbony")
                                    {
                                        newtexture = state.LinkCache.Resolve<ITextureSetGetter>(value.Replace("Material", "Ebony")).ToLink();
                                    }
                                    else if (material == "ALTDaedric")
                                    {
                                        newtexture = state.LinkCache.Resolve<ITextureSetGetter>(value.Replace("Material", "Daedric")).ToLink();
                                    }
                                    else
                                    {
                                        Console.WriteLine("Warning: Could not find texture replacement: " + textureset);
                                        continue;
                                    }
                                }
                                model.AlternateTextures.Add(new AlternateTexture()
                                {
                                    Name = nif.GetShapeNames()[index],
                                    Index = index,
                                    NewTexture = newtexture
                                });
                                foundreplacement = true;
                            }
                        }
                        if (!foundreplacement) Console.WriteLine("Warning: Could not find texture replacements for: " + armoraddon.EditorID + ": " + relativepath);
                    }
                }

                if (armoraddon.WorldModel != null)
                {
                    foreach (var model in armoraddon.WorldModel)
                    {
                        if (model == null) continue;

                        var relativepath = model.File;
                        var modelPath = state.DataFolderPath + "\\meshes\\" + relativepath;
                        NifFile nif = new();
                        if (File.Exists(modelPath))
                        {
                            Console.WriteLine("Found loose mesh for record: " + armoraddon.EditorID + ": " + relativepath);
                            nif.Load(modelPath);
                        }
                        else
                        {
                            if (TryGetFileFromArchive(archivereaders, "meshes\\" + relativepath, out var foundnif))
                            {
                                Console.WriteLine("Found mesh in bsa for record: " + armoraddon.EditorID + ": " + relativepath);
                                nif = foundnif;
                            }
                            else
                            {
                                Console.WriteLine("ERROR: Could not find model for record: " + armoraddon.EditorID + ": " + relativepath);
                                continue;
                            }
                        }

                        model.AlternateTextures = [];

                        bool foundreplacement = false;
                        var shapes = nif.GetShapes();
                        foreach (var shape in shapes)
                        {
                            var texurepath = nif.GetTexturePathByIndex(shape, 0);
                            if (verboseLogging) Console.WriteLine(texurepath);

                            var index = shapes.IndexOf(shape);
                            if (Overrides.TryGetValue(armoraddon.EditorID, out var overrides))
                            {
                                if (overrides.TryGetValue(texurepath, out var overridevalue))
                                {
                                    Console.WriteLine("Found texture override: " + overridevalue + ": " + texurepath);
                                    model.AlternateTextures.Add(new AlternateTexture()
                                    {
                                        Name = nif.GetShapeNames()[index],
                                        Index = index,
                                        NewTexture = state.LinkCache.Resolve<ITextureSetGetter>(overridevalue).ToLink()
                                    });
                                    foundreplacement = true;
                                    continue;
                                }
                            }
                            if (Textures.TryGetValue(texurepath, out var value))
                            {
                                string textureset = value.Replace("Material", material.ToString());
                                Console.WriteLine("Found texture replacement: " + textureset + ": " + texurepath);
                                IFormLink<ITextureSetGetter> newtexture;
                                if (state.LinkCache.TryResolve<ITextureSetGetter>(textureset, out var foundtexture))
                                {
                                    newtexture = foundtexture.ToLink();
                                }
                                else
                                {
                                    if (material == "ALTEbony")
                                    {
                                        newtexture = state.LinkCache.Resolve<ITextureSetGetter>(value.Replace("Material", "Ebony")).ToLink();
                                    }
                                    else if (material == "ALTDaedric")
                                    {
                                        newtexture = state.LinkCache.Resolve<ITextureSetGetter>(value.Replace("Material", "Daedric")).ToLink();
                                    }
                                    else
                                    {
                                        Console.WriteLine("Warning: Could not find texture replacement: " + textureset);
                                        continue;
                                    }
                                }
                                model.AlternateTextures.Add(new AlternateTexture()
                                {
                                    Name = nif.GetShapeNames()[index],
                                    Index = index,
                                    NewTexture = newtexture
                                });
                                foundreplacement = true;
                            }
                        }
                        if (!foundreplacement) Console.WriteLine("Warning: Could not find texture replacements for: " + armoraddon.EditorID + ": " + relativepath);
                    }
                }

                state.PatchMod.ArmorAddons.Set(armoraddon);
            }
        }
    }
}
