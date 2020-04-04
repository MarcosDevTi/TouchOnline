using DigiteMais.Domain.Enums;
using System.Collections.Generic;
using System.Linq;
using TouchOnline.Data.Services;
using TouchOnline.Domain;

namespace TouchOnline.CqrsHandlers
{
    public class LessonsPresentation
    {
        public HashSet<LessonPresentation> GetPresentation(string category, string language)
        {

            switch (category)
            {
                case "beginners":
                    {
                        return InicianteApresentacaoPt(0);
                    }

                case "basics":
                    {
                        return BasicoApresentacaoPt(true);
                    }
                case "intermediates":
                    {
                        return IntermediarioApresentacaoPt(true);
                    }
                case "advanceds":
                    {
                        return AvancadoApresentacaoPt(true);
                    }
                default:
                    {
                        return new HashSet<LessonPresentation>();
                    }
            }

        }

        public HashSet<LessonPresentation> GetPresentation(int idExerc)
        {
            var ex = FirstDigit(idExerc);
            switch (ex)
            {
                case 1: return InicianteApresentacaoPt(0);
                case 2: return BasicoApresentacaoPt(true);
                case 3: return IntermediarioApresentacaoPt(true);
                case 4: return AvancadoApresentacaoPt(true);
                default: return new HashSet<LessonPresentation>();
            }
        }

        private int FirstDigit(int num)
        {
            while (num >= 10) num /= 10;
            return num;
        }

        public HashSet<LessonPresentation> InicianteApresentacaoPt(int lCid)
        {
            if (Lcid.Pt.Contains(lCid))
            {
                return CriarInicianteBr();
            }
            else
            {
                return CriarInicianteBr();
            }
        }

        public HashSet<LessonPresentation> BasicoApresentacaoPt(bool premium)
        {
            var exerciciosPt = new HashSet<LessonPresentation>
                {
            CriarGenercApresent(2, 201, "01", "Básico", 45, "assa sala assa sala assa sala assa sala assa sala assa sala assa sala assa sala¶assa sala assa sala assa sala assa sala assa sala assa sala assa sala assa sala"),
            CriarGenercApresent(2, 202, "02", "Básico", 45, "dada fada dada fada dada fada dada fada dada fada dada fada dada fada dada fada¶dada fada dada fada dada fada dada fada dada fada dada fada dada fada dada fada"),
            CriarGenercApresent(2, 203, "03", "Básico", 45, "gaga haja gaga haja gaga haja gaga haja gaga haja gaga haja gaga haja gaga haja¶gaga haja gaga haja gaga haja gaga haja gaga haja gaga haja gaga haja gaga haja"),
            CriarGenercApresent(2, 204, "04", "Básico", 45, "assada sal assada sal assada sal assada sal assada sal assada sal assada sal¶assada sal assada sal assada sal assada sal assada sal assada sal assada sal"),
            CriarGenercApresent(2, 205, "05", "Básico", 45, "salsa fala salsa fala salsa fala salsa fala salsa fala salsa fala salsa fala¶salsa fala salsa fala salsa fala salsa fala salsa fala salsa fala salsa fala"),
            CriarGenercApresent(2, 206, "06", "Básico", 45, "falsa galga falsa galga falsa galga falsa galga falsa galga falsa galga¶falsa galga falsa galga falsa galga falsa galga falsa galga falsa galga"),
            CriarGenercApresent(2, 207, "07", "Básico", 45, "saldada halda saldada halda saldada halda saldada halda saldada halda sal¶saldada halda saldada halda saldada halda saldada halda saldada halda sal"),
            CriarGenercApresent(2, 208, "08", "Básico", 45, "salada faladas salada faladas salada faladas salada faladas salada salada¶salada faladas salada faladas salada faladas salada faladas salada salada"),
            CriarGenercApresent(2, 209, "09", "Básico", 45, "kada daka kada daka kada daka kada daka kada daka kada daka kada daka kada daka¶kada daka kada daka kada daka kada daka kada daka kada daka kada daka kada daka"),
            CriarGenercApresent(2, 210, "10", "Básico", 45, "querer quito querer quito querer quito querer quito querer quito querer quito¶querer quito querer quito querer quito querer quito querer quito querer quito"),
            CriarGenercApresent(2, 211, "11", "Básico", 45, "quoque reto quoque reto quoque reto teto quoque reto quoque reto quoque reto teto¶quoque reto quoque reto quoque reto teto quoque reto quoque reto quoque reto teto"),
            CriarGenercApresent(2, 212, "12", "Básico", 45, "trote topo trote topo trote topo trote topo trote topo trote topo trote topo¶trote topo trote topo trote topo trote topo trote topo trote topo trote topo"),
            CriarGenercApresent(2, 213, "13", "Básico", 45, "pote reitero pote reitero pote reitero pote reitero pote reitero pote reitero¶pote reitero pote reitero pote reitero pote reitero pote reitero pote reitero"),
            CriarGenercApresent(2, 214, "14", "Básico", 45, "requeiro ter requeiro ter requeiro ter requeiro ter requeiro ter requeiro ter¶requeiro ter requeiro ter requeiro ter requeiro ter requeiro ter requeiro ter"),
            CriarGenercApresent(2, 215, "15", "Básico", 45, "ara arara ara arara ara arara ara arara ara arara ara arara ara arara ara arara¶ara arara ara arara ara arara ara arara ara arara ara arara ara arara ara arara"),
            CriarGenercApresent(2, 216, "16", "Básico", 45, "qual aqui que aqui qual aquilo que quase qual aqui que aquilo qual aqui que qual¶aqui que aquilo qual aqui que aquilo qual aqui que aquilo qual aqui que qual"),
            CriarGenercApresent(2, 217, "17", "Básico", 45, "law way jaw owe law way jaw owe law way jaw owe law way jaw owe law way jaw owe¶law way jaw owe law way jaw owe law way jaw owe law way jaw owe law way jaw owe"),
            CriarGenercApresent(2, 218, "18", "Básico", 45, "ela esse ele essa ela esse ele essa ela esse ele essas ela esse ele essa ela ele¶esse essa ela esse ele essas ela esse ele essa ela esse ele essa ela esse ele"),
            CriarGenercApresent(2, 219, "19", "Básico", 45, "frase lara farra arara frase lara farra arara frase ara lara farra arara frase¶lara farra arara frase ara lara farra arara frase lara ara farra arara frase"),
            CriarGenercApresent(2, 220, "20", "Básico", 45, "ta lata data tal ta lata data tal tala lata data tal ta lata data tal ta lata¶data tal ta lata data tal ta lata data tal ta lata data tal ta lata data tal"),
            CriarGenercApresent(2, 221, "21", "Básico", 45, "ya kya syla sy ayala kya syla sya sy ya kya syla sy ya kya syla sy ya kya syla¶ya kya syla sy ya kya syla sy ya kya sy syla sy ya kya syla sy  ya kya syla syya"),
            CriarGenercApresent(2, 222, "22", "Básico", 45, "lua usa sula fusa lua abusa sula fusa lua usa sula fusa lua usa sula fusa lua¶abusa sula fusa lua usa sula fusa lua usa sula fusa lua abusa sula fusa lua"),
            CriarGenercApresent(2, 223, "23", "Básico", 45, "dia lisa fila falida dia lisa fila dia falida dia lisa fila falida dia filha¶falida dias lisa fila falida dia lisa fila falida dias lisa fila falida dia"),
            CriarGenercApresent(2, 224, "24", "Básico", 45, "osso lousa oi fado osso lousa oi fado osso lousa folia fado osso lousa oi fado¶osso lousa oi fado ossos lousa oi fado osso lousa oi fado osso lousa oi fado"),
            CriarGenercApresent(2, 225, "25", "Básico", 45, "passe sapo fip lapa passe sapo fip lapa passe sapo fila lapa passe sapo fip fap¶lapa passe sapo fip lapa passe sapo fip lapa passe sapo fip lapa passe sapo fap"),
            CriarGenercApresent(2, 226, "26", "Básico", 45, "paz zip giz azul paz zip giz azul paz zip giz azul paz zip giz azul paz zip¶giz azul paz zip giz azul paz zip giz azul paz zip giz azul paz zip giz azul"),
            CriarGenercApresent(2, 227, "27", "Básico", 45, "faixa puxa xadrez lexo faixa puxar lexa xadrez reflexo faixa puxa xadrez flexa¶faixa puxa xadrez lexo faixa puxar lexa xadrez reflexo faixa puxa xadrez flexa"),
            CriarGenercApresent(2, 228, "28", "Básico", 45, "faca casa jaca cala faca casa jaca cala faca casa jaca cala faca casa jaca cala vai lava¶faca casa jaca cala faca casa jaca cala faca casa jaca cala faca casa jaca cala"),
            CriarGenercApresent(2, 229, "29", "Básico", 45, "vai lava ovo luva vai lava ovo luva vaca lava ovos luva vai lava ovo luva vai ave¶vai lava ovo luva vai lava ovo luva vaca lava ovos luva vai lava ovo luva vai ave"),
            CriarGenercApresent(2, 230, "30", "Básico", 45, "lobo aba sabe boa lobo aba sabe boa lobo aba sabe saber lobo aba sabe boa lobo¶sabe boa lobo aba sabe boa lobo aba sabe saber lobo aba sabe boa lobo aba sabe"),
            CriarGenercApresent(2, 231, "31", "Básico", 45, "na nela ana anel na nela ana anel nula nela ana anel sana nela ana anel nula¶na nela ana anel na nela ana anel nula nela ana anel sana nela ana anel nula"),
            CriarGenercApresent(2, 232, "32", "Básico", 45, "ama mal mala ema ama mal mala ema mama mal mala ema amei mal mala ema mamamia¶ama mal mala ema ama mal mala ema mama mal mala ema amei mal mala ema mamamia"),
            CriarGenercApresent(2, 233, "33", "Básico", 45, "idéia é idéia é idéia é idéia é idéia é idéia é idéia é idéia é idéia é idéia é¶idéia é idéia é idéia é idéia é idéia é idéia é idéia é idéia é idéia é idéia é"),
            CriarGenercApresent(2, 234, "34", "Básico", 45, "só fúria só fúria só fúria só fúria só fúria só fúria só fúria só fúria sódio¶só fúria só fúria só fúria só fúria só fúria só fúria só fúria só fúria sódio"),
            CriarGenercApresent(2, 235, "35", "Básico", 45, "tânia avô tânia avô tânia avô tânia avô tânia avô tânia avô tânia avô tânia avô¶tânia avô tânia avô tânia avô tânia avô tânia avô tânia avô tânia avô tânia avô"),
            CriarGenercApresent(2, 236, "36", "Básico", 45, "câmbio ânsia câmbio ânsia câmbio ânsia câmbio ânsia câmbio ânsia câmbio ânsia¶ânsia câmbio ânsia câmbio ânsia câmbio câmbio ânsia câmbio ânsia ânsia câmbio"),
            CriarGenercApresent(2, 237, "37", "Básico", 45, "pão mão pão mão pão mão pão mão pão mão pão mão pão mão pão mão pão mão pão mão¶pão mão pão mão pão mão pão mão pão mão pão mão pão mão pão mão mão pão mão pão mão pão mão"),
            CriarGenercApresent(2, 238, "38", "Básico", 45, "sã manhã sã manhã sã manhã sã manhã sã manhã sã manhã sã manhã sã manhã salão¶sã manhã sã manhã sã manhã sã manhã sã manhã sã manhã sã manhã sã manhã salão"),
            CriarGenercApresent(2, 239, "39", "Básico", 45, "à fé à fé à fé à fé à fé à fé à fé à fé à fé à fé à fé à fé à fé à fé à fé à fé¶à fé à fé à fé à fé à fé à fé à fé à fé à fé à fé à fé à fé à fé à fé à fé à fé"),
            CriarGenercApresent(2, 240, "40", "Básico", 45, "Titã químico Titã químico Titã químico Titã químico Titã químico Titã químico¶Titã químico Titã químico Titã químico Titã químico Titã químico Titã químico"),
            CriarGenercApresent(2, 241, "41", "Básico", 45, "álcool éter álcool éter álcool hétero álcool éter álcool éter álcool hétero¶álcool éter álcool éter álcool hétero álcool éter álcool éter álcool hétero"),
        };
            return SetarPremiumPt(exerciciosPt, 207, premium);
        }
        public HashSet<LessonPresentation> BasicoApresentacaoEn()
        {
            var exercicios = new HashSet<LessonPresentation>()
            {
                 #region Lista Básico
            CriarGenercApresent(2, 201, "01", "ci", 60, "cia acid flic alcid click disc facial fiscal alicia classic flaccid cadillac¶cia acid flic alcid click disc facial fiscal alicia classic flaccid cadillac"),
            CriarGenercApresent(2, 202, "02", "em", 55, "ema med adams leam seam same gamed male flames jeames smells message small¶ema med adams leam seam same gamed male flames jeames smells message small"),
            CriarGenercApresent(2, 203, "03", "pv", 55, "elapse please eva dave eaves level valse vedas laved leaved savage favela save¶elapse please eva dave eaves level valse vedas laved leaved savage favela save"),
            CriarGenercApresent(2, 204, "04", "wn", 55, "now own down know snown wagons ashdown low show flown woods fallow donk noda¶now own down know snown wagons ashdown low show flown woods fallow donk noda"),
            CriarGenercApresent(2, 205, "05", "xr", 55, "flux oxford ara kur ajar darl ajax hard kurd rhos sara roll floor russo shark¶flux oxford ara kur ajar darl ajax hard kurd rhos sara roll floor russo shark"),
            CriarGenercApresent(2, 206, "06", "tb", 45, "tab bath beat best boast abeat booth ballet beetle debate stable tabless fat¶tab bath beat best boast abeat booth ballet beetle debate stable tabless fat"),
            CriarGenercApresent(2, 207, "07", "yz", 50, "gazy eazily laydeez day addy gaya yesh asyla filly khaya flaily kailey lyases¶gazy eazily laydeez day addy gaya yesh asyla filly khaya flaily kailey lyases"),
            CriarGenercApresent(2, 208, "08", "saldf", 45, "salada faladas salada faladas salada faladas salada faladas salada salada¶salada faladas salada faladas salada faladas salada faladas salada salada"),
            CriarGenercApresent(2, 209, "09", "kad", 45, "kada daka kada daka kada daka kada daka kada daka kada daka kada daka kada daka¶kada daka kada daka kada daka kada daka kada daka kada daka kada daka kada daka"),
            CriarGenercApresent(2, 210, "10", "q", 60, "quad equal aquila kaique sequel liquid quailed squills odalique filioques dad¶quad equal aquila kaique sequel liquid quailed squills odalique filioques dad"),
            CriarGenercApresent(2, 211, "11", "eu", 45, "eua duke due use eula fuse lude slue used uses flued juked ludes jesus duffle¶eua duke due use eula fuse lude slue used uses flued juked ludes jesus duffle"),
            CriarGenercApresent(2, 212, "12", "troep", 55, "aio iso asio fifo kilo loid sofi loli adios oasis sofia solid skillo sialoid¶aio iso asio fifo kilo loid sofi loli adios oasis sofia solid skillo sialoid"),
            CriarGenercApresent(2, 213, "13", "gh", 55, "ghua hagg hug hugo daugh ghosh haugh hugged sleigh laughe hudges haig hog¶ghua hagg hug hugo daugh ghosh haugh hugged sleigh laughe hudges haig hog¶"),
            CriarGenercApresent(2, 214, "14", "p", 55, "dapo deop flop ipod keep kepi kipa nipa nope pale pana peed salp voip dipse¶dapo deop flop ipod keep kepi kipa nipa nope pale pana peed salp voip dipse"),
            CriarGenercApresent(2, 215, "15", "c", 60, "cia acai aicc caid huck luca luci acould ascid calli calud facia lucas adcock cid¶cia acai aicc caid huck luca luci acould ascid calli calud facia lucas adcock cid"),
            #endregion
            };
            return exercicios;
        }
        public HashSet<LessonPresentation> BasicoApresentacaoFr()
        {
            var exerciciosFr = new HashSet<LessonPresentation>()
                {
            CriarGenercApresent(2, 201, "01", "en", 60, "ane dene elan esen fena lena nell sene nefs alane dande danse elane kenaf kenna¶ane dene elan esen fena lena nell sene nefs alane dande danse elane kenaf kenna"),
            CriarGenercApresent(2, 202, "02", "pv", 55, "vespa opava pelve pavel svp depava aspa jeep kelp pepe soap java leva love aval¶vespa opava pelve pavel svp depava aspa jeep kelp pepe soap java leva love aval"),
            CriarGenercApresent(2, 203, "03", "oc", 55, "cao codo coco coda cola calo asco jaco floc socs odac loco cacao local flock¶cao codo coco coda cola calo asco jaco floc socs odac loco cacao local flock"),
            CriarGenercApresent(2, 204, "04", "z", 55, "jazz zoo laze ailez aluze azole deluz zouka louze azaila dallez zuides soldez¶jazz zoo laze ailez aluze azole deluz zouka louze azaila dallez zuides soldez"),
            CriarGenercApresent(2, 205, "05", "x", 55, "fax xie eux daix daux deux dixe faxe jeux loix axial exils faulx fluxe saxes¶fax xie eux daix daux deux dixe faxe jeux loix axial exils faulx fluxe saxes"),
            CriarGenercApresent(2, 206, "06", "v", 45, "ave dive elva fuve levi love sava veul vies ivo vue avais laval livie voila¶ave dive elva fuve levi love sava veul vies ivo vue avais laval livie voila"),
            CriarGenercApresent(2, 207, "07", "b", 50, "bad bau usb lab able bede juba obei subi abada basse aba blues gobie lobai abella¶bad bau aba usb lab able bede juba obei subi abada basse blues gobie abella"),
            CriarGenercApresent(2, 208, "08", "y", 45, "oye alya lyfa yole doyke aloya folly feluy fully aloysa gay adyle dailly loi¶oye alya lyfa yole doyke aloya folly feluy fully aloysa gay adyle dailly loi"),
            CriarGenercApresent(2, 209, "09", "w", 45, "daw wow wad kew awa fow wail wake wiki wasl show slow hawai lewis wases whisk¶daw wow wad kew awa fow wail wake wiki wasl show slow hawai lewis whisk wases"),
            CriarGenercApresent(2, 210, "10", "t", 60, "ate kit toe tue ato ejet faut lift loto sata sait teuf delta gesta jetai lates¶ate kit toe tue ato ejet faut lift loto sata sait teuf delta gesta jetai lates"),
            CriarGenercApresent(2, 211, "11", "q", 45, "quad equal aquila kaique sequel liquid squills odalique filioques alqaeda¶quad equal aquila kaique sequel liquid squills odalique filioques alqaeda"),
            CriarGenercApresent(2, 212, "12", "r", 55, "air aero dre rai doure earl rue four frik greg igor lira sera user agrea¶air aero dre rai doure earl rue four frik greg igor lira sera user agrea"),
            CriarGenercApresent(2, 213, "13", "m", 55, "ama moi aime dame made mois sumo agame doume filme image maida demode flames¶ama moi aime dame made mois sumo agame doume filme image maida demode flames"),
            CriarGenercApresent(2, 214, "14", "n", 55, "fan ken une agno dune goon hank king nasa neuf fasin fenai jaine logan none¶fan ken une agno dune goon hank king nasa neuf fasin fenai jaine logan none"),
            CriarGenercApresent(2, 215, "15", "gh", 60, "gui hagi hugo helga shogi lahage shogis sleigh gao gia sig leg gael hao dah hua¶gui hagi hugo helga shogi lahage shogis sleigh gao gia sig leg gael hao dah hua"),
        };
            return exerciciosFr;
        }
        public HashSet<LessonPresentation> BasicoApresentacaoEs()
        {
            return new HashSet<LessonPresentation>()
            {
            CriarGenercApresent(2, 201, "01", "asl", 60, "assa sala assa sala assa sala assa sala assa sala assa sala assa sala assa sala¶assa sala assa sala assa sala assa sala assa sala assa sala assa sala assa sala"),
            CriarGenercApresent(2, 202, "02", "daf", 55, "dada fada dada fada dada fada dada fada dada fada dada fada dada fada dada fada¶dada fada dada fada dada fada dada fada dada fada dada fada dada fada dada fada"),
            CriarGenercApresent(2, 203, "03", "gahj", 55, "gaga haja gaga haja gaga haja gaga haja gaga haja gaga haja gaga haja gaga haja¶gaga haja gaga haja gaga haja gaga haja gaga haja gaga haja gaga haja gaga haja"),
            CriarGenercApresent(2, 204, "04", "asdl", 55, "assada sal assada sal assada sal assada sal assada sal assada sal assada sal¶assada sal assada sal assada sal assada sal assada sal assada sal assada sal"),
            CriarGenercApresent(2, 205, "05", "salf", 55, "salsa fala salsa fala salsa fala salsa fala salsa fala salsa fala salsa fala¶salsa fala salsa fala salsa fala salsa fala salsa fala salsa fala salsa fala"),
            CriarGenercApresent(2, 206, "06", "falsg", 45, "falsa galga falsa galga falsa galga falsa galga falsa galga falsa galga falsa galga¶falsa galga falsa galga falsa galga falsa galga falsa galga falsa galga falsa galga"),
            CriarGenercApresent(2, 207, "07", "saldhd", 50, "saldada halda saldada halda saldada halda saldada halda saldada halda sal¶saldada halda saldada halda saldada halda saldada halda saldada halda sal"),
            CriarGenercApresent(2, 208, "08", "saldf", 45, "salada faladas salada faladas salada faladas salada faladas salada salada¶salada faladas salada faladas salada faladas salada faladas salada salada"),
            CriarGenercApresent(2, 209, "09", "kad", 45, "kada daka kada daka kada daka kada daka kada daka kada daka kada daka kada daka¶kada daka kada daka kada daka kada daka kada daka kada daka kada daka kada daka"),
            CriarGenercApresent(2, 210, "10", "querit", 60, "querer quito querer quito querer quito querer quito querer quito querer quito¶querer quito querer quito querer quito querer quito querer quito querer quito"),
            CriarGenercApresent(2, 211, "11", "quoetr", 45, "quoque reto quoque reto quoque reto teto quoque reto quoque reto quoque reto teto¶quoque reto quoque reto quoque reto teto quoque reto quoque reto quoque reto teto"),
            CriarGenercApresent(2, 212, "12", "troep", 55, "trote topo trote topo trote topo trote topo trote topo trote topo trote topo¶trote topo trote topo trote topo trote topo trote topo trote topo trote topo"),
            CriarGenercApresent(2, 213, "13", "poteri", 55, "pote reitero pote reitero pote reitero pote reitero pote reitero pote reitero¶pote reitero pote reitero pote reitero pote reitero pote reitero pote reitero"),
            CriarGenercApresent(2, 214, "14", "requio", 55, "requeiro ter requeiro ter requeiro ter requeiro ter requeiro ter requeiro ter¶requeiro ter requeiro ter requeiro ter requeiro ter requeiro ter requeiro ter"),
            CriarGenercApresent(2, 215, "15", "ar", 60, "ara arara ara arara ara arara ara arara ara arara ara arara ara arara ara arara¶ara arara ara arara ara arara ara arara ara arara ara arara ara arara ara arara"),
            };
        }
        public HashSet<LessonPresentation> IntermediarioApresentacaoPt(bool premium)
        {
            var exerciciosPt = new HashSet<LessonPresentation>()
                {
                 CriarGenercApresent(3, 301, "01", "Geral", 45, "Um novo tempo, um novo tempo. Um novo tempo, um novo tempo. Um novo tempo, um novo tempo. Um novo tempo, um novo tempo. Um novo tempo, um novo tempo. Um novo¶tempo, um novo tempo. Um novo tempo, um novo tempo. Um novo tempo, um novo tempo. Um novo tempo, um novo tempo. Um novo tempo, um novo tempo. Um novo tempo."),
                 CriarGenercApresent(3, 302, "02", "Geral", 45, "Sobre muitas coisas, sobre muitas coisas. Sobre muitas coisas, sobre muitas coisas. Sobre muitas coisas, sobre muitas coisas. Sobre muitas coisas, sobre muitas¶coisas. Sobre muitas coisas, sobre muitas coisas. Sobre muitas coisas, sobre muitas coisas. Sobre muitas coisas, sobre muitas coisas. Sobre muitas coisas."),
                 CriarGenercApresent(3, 303, "03", "Geral", 45, "Por que você se foi? Por que você se foi? Por que você se foi? Por que você se foi? Por que você se foi? Por que você se foi? Por que você se foi? Por que você se¶foi? Por que você se foi? Por que você se foi? Por que você se foi? Por que você se foi? Por que você se foi? Por que você se foi? Por que você se foi?"),
                 CriarGenercApresent(3, 304, "04", "Geral", 45, "Eu quero apenas falar, eu quero apenas falar. Eu quero apenas falar, eu quero apenas falar. Eu quero apenas falar, eu quero apenas falar. Eu quero apenas falar, eu¶quero apenas falar. Eu quero apenas falar, eu quero apenas falar. Eu quero apenas falar, eu quero apenas falar. Eu quero apenas falar, eu quero apenas falar."),
                 CriarGenercApresent(3, 305, "05", "Geral", 45, "Não me impeça, por favor! Não me impeça, por favor! Não me impeça, por favor! Não me impeça, por favor! Não me impeça, por favor! Não me impeça, por favor! Não me¶impeça, por favor! Não me impeça, por favor! Não me impeça, por favor! Não me impeça, por favor! Não me impeça, por favor! Não me impeça, por favor!"),
                 CriarGenercApresent(3, 306, "06", "Geral", 45, "Agora é tarde pra voltar, agora é tarde pra voltar. Agora é tarde pra voltar, agora é tarde pra voltar. Agora é tarde pra voltar, agora é tarde pra voltar.¶Agora é tarde pra voltar, agora é tarde pra voltar. Agora é tarde pra voltar, agora é tarde pra voltar. Agora é tarde pra voltar, agora é tarde pra voltar."),
                 CriarGenercApresent(3, 307, "07", "Geral", 45, "Hoje não está, hoje não é. Hoje não está, hoje não é. Hoje não está, hoje não é. Hoje não está, hoje não é. Hoje não está, hoje não é. Hoje não está, hoje não é.¶Hoje não está, hoje não é. Hoje não está, hoje não é. Hoje não está, hoje não é. Hoje não está, hoje não é. Hoje não está, hoje não é. Hoje não está, hoje não é."),
                 CriarGenercApresent(3, 308, "08", "Geral", 45, "Por que não explica, o porquê disso tudo? Por que não explica, o porquê disso tudo? Por que não explica, o porquê disso tudo? Por que não explica, o porquê disso¶tudo? Por que não explica, o porquê disso tudo? Por que não explica, o porquê disso tudo? Por que não explica, o porquê disso tudo?"),
                 CriarGenercApresent(3, 309, "09", "Geral", 45, "Conto com você hoje às 7 da manhã. Conto com você hoje às 7 da manhã. Conto com você hoje às 7 da manhã. Conto com você hoje às 7 da manhã. Conto com você hoje às 7¶da manhã. Conto com você hoje às 7 da manhã. Conto com você hoje às 7 da manhã. Conto com você hoje às 7 da manhã. Conto com você hoje às 7 da manhã."),
                 CriarGenercApresent(3, 310, "10", "Geral", 45, "Após o início, será fácil. Após o início, será fácil. Após o início, será fácil. Após o início, será fácil. Após o início, será fácil. Após o início, será fácil.¶Após o início, será fácil. Após o início, será fácil. Após o início, será fácil. Após o início, será fácil. Após o início, será fácil. Após o início, será fácil."),
                 CriarGenercApresent(3, 311, "11", "Geral", 45, "Aqui somente é visível a usuários logados. Aqui somente é visível a usuários logados. Aqui somente é visível a usuários logados. Aqui somente é visível a usuários¶logados. Aqui somente é visível a usuários logados. Aqui somente é visível a usuários logados. Aqui somente é visível a usuários logados."),
                 CriarGenercApresent(3, 312, "12", "Geral", 45, "O touch online é tão fácil! O touch online é tão fácil! O touch online é tão fácil! O touch online é tão fácil! O touch online é tão fácil! O touch online é tão fácil! O¶touch online é tão fácil! O touch online é tão fácil! O touch online é tão fácil! O touch online é tão fácil! O touch online é tão fácil! O touch online é tão fácil!"),
                 CriarGenercApresent(3, 313, "13", "Geral", 45, "O resultado será satisfatório, o resultado será satisfatório. O resultado será satisfatório, o resultado será satisfatório. O resultado será¶satisfatório, o resultado será satisfatório. O resultado será satisfatório, o resultado será satisfatório. O resultado será satisfatório."),
                 CriarGenercApresent(3, 314, "14", "Geral", 45, "Você está utilizando os dedos corretos? Você está utilizando os dedos corretos? Você está utilizando os dedos corretos? Você está utilizando os dedos corretos?¶Você está utilizando os dedos corretos? Você está utilizando os dedos corretos? Você está utilizando os dedos corretos? Você está utilizando os dedos corretos?"),
                 CriarGenercApresent(3, 315, "15", "Geral", 45, "Hoje é um excelente dia para estudar, hoje é um excelente dia para estudar. Hoje é um excelente dia para estudar, hoje é um excelente dia para estudar.¶Hoje é um excelente dia para estudar, hoje é um excelente dia para estudar. Hoje é um excelente dia para estudar, hoje é um excelente dia para estudar."),
                 CriarGenercApresent(3, 316, "16", "Geral", 45, "Não olhe para o teclado! Não olhe para o teclado! Não olhe para o teclado! Não olhe para o teclado! Não olhe para o teclado! Não olhe para o teclado! Não olhe para¶o teclado! Não olhe para o teclado! Não olhe para o teclado! Não olhe para o teclado! Não olhe para o teclado! Não olhe para o teclado!"),
                 CriarGenercApresent(3, 317, "17", "Geral", 45, "Já é tarde, amanhã é outro dia. Já é tarde, amanhã é outro dia. Já é tarde, amanhã é outro dia. Já é tarde, amanhã é outro dia. Já é tarde, amanhã é outro dia. Já¶é tarde, amanhã é outro dia. Já é tarde, amanhã é outro dia. Já é tarde, amanhã é outro dia. Já é tarde, amanhã é outro dia. Já é tarde, amanhã é outro dia."),
                 CriarGenercApresent(3, 318, "18", "Geral", 45, "Faça frio ou faça sol, faça frio ou faça sol. Faça frio ou faça sol, faça frio ou faça sol. Faça frio ou faça sol, faça frio ou faça sol. Faça frio ou faça sol, faça¶frio ou faça sol. Faça frio ou faça sol, Faça frio ou faça sol. Faça frio ou faça sol, faça frio ou faça sol. Faça frio ou faça sol, Faça frio ou faça sol."),
                 CriarGenercApresent(3, 319, "19", "Geral", 45, "É imprescindível digitar bem, é imprescindível digitar bem. É imprescindível digitar bem, é imprescindível digitar bem. É imprescindível digitar bem, é¶imprescindível digitar bem. É imprescindível digitar bem, é imprescindível digitar bem. É imprescindível digitar bem, é imprescindível digitar bem."),
                 CriarGenercApresent(3, 320, "20", "Geral", 45, "Será fácil se não desistir no início. Será fácil se não desistir no início. Será fácil se não desistir no início. Será fácil se não desistir no início. Será¶fácil se não desistir no início. Será fácil se não desistir no início. Será fácil se não desistir no início. Será fácil se não desistir no início."),
               };

            return SetarPremiumPt(exerciciosPt, 305, premium);
        }
        public HashSet<LessonPresentation> IntermediarioApresentacaoFr()
        {
            return new HashSet<LessonPresentation>()
            {
            #region Lista Intermediário
            CriarGenercApresent(3, 301, "01", "Général", 50, "Les nouvelles technologies irriguent l'économie du pays. Les nouvelles technologies irriguent l'économie du pays. Les nouvelles technologies irriguent¶l'économie du pays. Les nouvelles technologies irriguent l'économie du pays. Les nouvelles technologies irriguent l'économie du pays."),
            CriarGenercApresent(3, 302, "02", "Général", 50, "Ses membres ne sont toujours pas mis d'accord. Ses membres ne sont toujours pas mis d'accord. Ses membres ne sont toujours pas mis d'accord. Ses membres ne¶sont toujours pas mis d'accord. Ses membres ne sont toujours pas mis d'accord. Ses membres ne sont toujours pas mis d'accord. Ses membres ne sont toujours pas mis¶d'accord."),
            CriarGenercApresent(3, 303, "03", "Général", 50, "Les deux chanteurs ont été sacrés meilleurs artistes de l'année. Les deux chanteurs ont été sacrés meilleurs artistes de l'année. Les deux chanteurs ont été¶sacrés meilleurs artistes de l'année. Les deux chanteurs ont été sacrés meilleurs artistes de l'année. Les deux chanteurs ont été sacrés meilleurs artistes de¶l'année."),
            CriarGenercApresent(3, 304, "04", "Général", 50, "Une exposition réunit des toiles de la collection. Une exposition réunit des toiles de la collection. Une exposition réunit des toiles de la collection. Une¶exposition réunit des toiles de la collection. Une exposition réunit des toiles de la collection. Une exposition réunit des toiles de la collection."),
            CriarGenercApresent(3, 305, "05", "Général", 50, "Jusqu'à la fin du mois de février. Jusqu'à la fin du mois de février. Jusqu'à la fin du mois de février. Jusqu'à la fin du mois de février. Jusqu'à la fin du¶mois de février. Jusqu'à la fin du mois de février. Jusqu'à la fin du mois de février. Jusqu'à la fin du mois de février. Jusqu'à la fin du mois de février."),
            CriarGenercApresent(3, 306, "06", "Général", 50, "Les jardins deviennent des lieux de représentation. Les jardins deviennent des lieux de représentation. Les jardins deviennent des lieux de représentation. Les¶jardins deviennent des lieux de représentation. Les jardins deviennent des lieux de représentation. Les jardins deviennent des lieux de représentation."),
            CriarGenercApresent(3, 307, "07", "Général", 50, "Le premier est une miniature. Le premier est une miniature. Le premier est une miniature. Le premier est une miniature. Le premier est une miniature. Le¶premier est une miniature. Le premier est une miniature. Le premier est une miniature. Le premier est une miniature. Le premier est une miniature. Le premier¶est une miniature."),
            CriarGenercApresent(3, 308, "08", "Général", 50, "Les tests de dactylo gratuits. Les tests de dactylo gratuits. Les tests de dactylo gratuits. Les tests de dactylo gratuits. Les tests de dactylo gratuits. Les¶tests de dactylo gratuits. Les tests de dactylo gratuits. Les tests de dactylo gratuits. Les tests de dactylo gratuits. Les tests de dactylo gratuits."),
            CriarGenercApresent(3, 309, "09", "Général", 50, "Soyez le premier à réagir. Soyez le premier à réagir. Soyez le premier à réagir. Soyez le premier à réagir. Soyez le premier à réagir. Soyez le premier à réagir.¶Soyez le premier à réagir. Soyez le premier à réagir. Soyez le premier à réagir. Soyez le premier à réagir. Soyez le premier à réagir. Soyez le premier à réagir."),
            CriarGenercApresent(3, 310, "10", "Général", 50, "La situation est la plus préoccupante. La situation est la plus préoccupante. La situation est la plus préoccupante. La situation est la plus préoccupante.¶La situation est la plus préoccupante. La situation est la plus préoccupante. La situation est la plus préoccupante. La situation est la plus préoccupante."),
            CriarGenercApresent(3, 311, "11", "Général", 50, "Ce réacteur a été mis hors service jeudi. Ce réacteur a été mis hors service jeudi. Ce réacteur a été mis hors service jeudi. Ce réacteur a été mis hors service¶jeudi. Ce réacteur a été mis hors service jeudi. Ce réacteur a été mis hors service jeudi. Ce réacteur a été mis hors service jeudi."),
            CriarGenercApresent(3, 312, "12", "Général", 50, "Ce dispositif devrait permettre de préserver les écosystèmes. Ce dispositif devrait permettre de préserver les écosystèmes. Ce dispositif devrait¶permettre de préserver les écosystèmes. Ce dispositif devrait permettre de préserver les écosystèmes. Ce dispositif devrait permettre de préserver les¶écosystèmes."),
            CriarGenercApresent(3, 313, "13", "Général", 50, "Dans le centre et le sud du département. Dans le centre et le sud du département. Dans le centre et le sud du département. Dans le centre et le sud du département.¶Dans le centre et le sud du département. Dans le centre et le sud du département. Dans le centre et le sud du département. Dans le centre et le sud du département."),
            CriarGenercApresent(3, 314, "14", "Général", 50, "En fonction de l'évolution de la situation. En fonction de l'évolution de la situation. En fonction de l'évolution de la situation. En fonction de l'évolution¶de la situation. En fonction de l'évolution de la situation. En fonction de l'évolution de la situation. En fonction de l'évolution de la situation."),
            CriarGenercApresent(3, 315, "15", "Général", 50, "C'est le troisième échouement de cette ampleur. C'est le troisième échouement de cette ampleur. C'est le troisième échouement de cette ampleur. C'est le¶troisième échouement de cette ampleur. C'est le troisième échouement de cette ampleur. C'est le troisième échouement de cette ampleur."),
            CriarGenercApresent(3, 316, "16", "Général", 50, "Les meilleurs freerideurs de la planète se sont retrouvés. Les meilleurs freerideurs de la planète se sont retrouvés. Les meilleurs freerideurs de la planète¶se sont retrouvés. Les meilleurs freerideurs de la planète se sont retrouvés. Les meilleurs freerideurs de la planète se sont retrouvés."),
            CriarGenercApresent(3, 317, "17", "Général", 50, "Apprenez à utiliser correctement le clavier. Apprenez à utiliser correctement le clavier. Apprenez à utiliser correctement le clavier. Apprenez à utiliser¶correctement le clavier. Apprenez à utiliser correctement le clavier. Apprenez à utiliser correctement le clavier."),
            CriarGenercApresent(3, 318, "18", "Général", 50, "Une explosion a frappé une usine chimique. Une explosion a frappé une usine chimique. Une explosion a frappé une usine chimique. Une explosion a frappé une¶usine chimique. Une explosion a frappé une usine chimique. Une explosion a frappé une usine chimique. Une explosion a frappé une usine chimique."),
            CriarGenercApresent(3, 319, "19", "Général", 40, "Un départ de feu, circonscrit, est survenu dans la salle. Un départ de feu, circonscrit, est survenu dans la salle. Un départ de feu, circonscrit, est survenu¶dans la salle. Un départ de feu, circonscrit, est survenu dans la salle. Un départ de feu, circonscrit, est survenu dans la salle."),
            CriarGenercApresent(3, 320, "20", "Général", 30, "La Franccaise s'est imposée. La Franccaise s'est imposée. La Franccaise s'est imposée. La Franccaise s'est imposée. La Franccaise s'est imposée. La Franccaise s'est imposée.¶La Franccaise s'est imposée. La Franccaise s'est imposée. La Franccaise s'est imposée. La Franccaise s'est imposée. La Franccaise s'est imposée."),
            CriarGenercApresent(3, 321, "21", "Général", 35, "Vous saurez écrire très vite avec vos 10 doigts. Vous saurez écrire très vite avec vos 10 doigts. Vous saurez écrire très vite avec vos 10 doigts. Vous saurez écrire¶très vite avec vos 10 doigts. Vous saurez écrire très vite avec vos 10 doigts. Vous saurez écrire très vite avec vos 10 doigts."),
            CriarGenercApresent(3, 322, "22", "Général", 35, "Dominés tout au long de la rencontre. Dominés tout au long de la rencontre. Dominés tout au long de la rencontre. Dominés tout au long de la rencontre.¶Dominés tout au long de la rencontre. Dominés tout au long de la rencontre. Dominés tout au long de la rencontre. Dominés tout au long de la rencontre."),
            CriarGenercApresent(3, 323, "23", "Général", 60, "Les premiers du classement se sont imposés largement. Les premiers du classement se sont imposés largement. Les premiers du classement se sont imposés largement.¶Les premiers du classement se sont imposés largement. Les premiers du classement se sont imposés largement. Les premiers du classement se sont imposés largement."),
            CriarGenercApresent(3, 324, "24", "Général", 30, "Notre application peut vous aider à apprendre. Notre application peut vous aider à apprendre. Notre application peut vous aider à apprendre. Notre¶application peut vous aider à apprendre. Notre application peut vous aider à apprendre. Notre application peut vous aider à apprendre."),
            CriarGenercApresent(3, 325, "25", "Général", 30, "Qu'avons-nous appris? Qu'avons-nous appris? Qu'avons-nous appris? Qu'avons-nous appris? Qu'avons-nous appris? Qu'avons-nous appris? Qu'avons-nous appris?¶Qu'avons-nous appris? Qu'avons-nous appris? Qu'avons-nous appris? Qu'avons-nous appris? Qu'avons-nous appris? Qu'avons-nous appris? Qu'avons-nous appris?"),
            CriarGenercApresent(3, 326, "26", "Général", 30,  "Des jeux familiaux pour se raconter des histoires. Des jeux familiaux pour se raconter des histoires. Des jeux familiaux pour se raconter des histoires. Des jeux¶familiaux pour se raconter des histoires. Des jeux familiaux pour se raconter des histoires. Des jeux familiaux pour se raconter des histoires."),
                        };
            #endregion
        }
        public HashSet<LessonPresentation> AvancadoApresentacaoPt(bool premium)
        {
            var exerciciosPt = new HashSet<LessonPresentation>()
                {
            CriarGenercApresent(4, 401, "01", "Geral", 45, "A técnica básica de datilografia consiste em manter os pulsos erguidos, ao invés de apoiá-los sobre a mesa, pois isso pode causar síndrome do túnel carpal. O¶datilógrafo deve manter os cotovelos ao lado do corpo, levantar ligeiramente as mãos sobre o teclado. A maneira mais eficiente de datilografar é manter os¶olhos na tela do dispositivo, corrigindo possíveis erros mais rapidamente. Essa técnica se chama datilografia por toque. Quando não a utiliza, diz-se¶que a pessoa está \"catando milho\". Atualmente, quase todo teclado possui marcas sobre as letras F e J, que servem para o datilógrafo encontrar a posição inicial¶de digitação apenas com o tato. Para pôr os dedos na posição inicial, basta colocar os dedos indicadores sobre as teclas marcadas, e os outros dedos sobre as¶teclas imediatamente vizinhas."),
            CriarGenercApresent(4, 402, "02", "Geral", 45, "O Touch Online vos oferece a possibilidade de criar seus próprios exercícios. Quando houver algum texto que você precise ler para estudar ou decorar, o melhor é¶inseri-lo no menu ferramentas, em seguida, criar exercício e ele ficará guardado na sua conta para quando quiser voltar a treiná-lo. Dessa forma estará¶ganhando tempo. Lembrando que essa opção só existe para quem se registra e é gratuito."),
            CriarGenercApresent(4, 403, "03", "Geral", 45, "Paulínia é um município brasileiro no interior do estado de São Paulo. Pertencente à mesorregião e microrregião de Campinas, localiza-se a noroeste da¶capital do estado, distando desta cerca de 119 quilômetros. Ocupa uma área de 139 quilômetros quadrados e sua população foi contada em 2010 pelo IBGE¶em 84.512 habitantes. Está localizado no eixo Rio-São Paulo, servindo de elo entre a Grande São Paulo e cidades da região, como Cosmópolis, Artur Nogueira e¶Conchal."),
            CriarGenercApresent(4, 404, "04", "Geral", 45, "Música clássica ou música erudita é o nome dado à principal variedade de música produzida ou enraizada nas tradições da música secular e litúrgica ocidental.¶Abrange um período amplo que vai aproximadamente do século IX até o presente e segue cânones preestabelecidos no decorrer da história da música. As¶normas centrais desta tradição foram codificadas entre 1675 e 1900, intervalo de tempo conhecido como o período da prática comum."),
            CriarGenercApresent(4, 405, "05", "Geral", 45, "Análise de sistemas é a atividade que tem como finalidade a realização de estudos de processos a fim de encontrar o melhor caminho racional para que a¶informação possa ser processada. Os analistas de sistemas estudam os diversos sistemas existentes entre hardwares (equipamentos), softwares (programas) e o¶usuário final. Os seus comportamentos e aplicações são desenvolvidos a partir de soluções que serão padronizadas e transcritas da forma que o computador¶possa executar."),
            CriarGenercApresent(4, 406, "06", "Geral", 45, "O principal problema na definição do que é arte é o fato de que esta definição varia com o tempo e de acordo com as várias culturas humanas. Devemos, pois,¶ter em mente que a própria definição de arte é uma construção cultural variável e sem significado constante. Muito do que hoje uma cultura ou grupo chama¶de arte não era ou não é considerado como tal por culturas ou grupos diferentes daqueles onde foi produzida, e até numa mesma época e numa mesma cultura¶pode haver múltiplas acepções do que é arte. As sociedades pré-industriais em geral não possuem ou possuíam sequer um termo para designar arte."),
            CriarGenercApresent(4, 407, "07", "Geral", 45, "Experiências isoladas realizadas em toda a Europa ao longo das décadas de 1860 e 1870 contribuíram para o aparecimento de algo semelhante ao automóvel atual. Uma¶das mais significativas foi a invenção de um pequeno carro impulsionado por um motor a quatro tempos, construído por Siegfried Markus (Viena, 1874). Os¶motores a vapor - que queimavam o combustível fora dos cilindros, deram lugar aos motores de combustão interna, que queimavam no interior do cilindro uma¶mistura de ar e gás de iluminação."),
            CriarGenercApresent(4, 408, "08", "Geral", 45, "Tudo começou com a tentativa de desenvolver uma máquina capaz de calcular polinômios por meio de diferenças, o calculador diferencial. Enquanto projetava seu¶calculador diferencial, a ideia de Jacquard fez com que Babbage imaginasse uma nova e mais complexa máquina, o calculador analítico, máquina com alguns elementos que¶remetem aos computadores atuais"),
            CriarGenercApresent(4, 409, "09", "Geral", 45, "A física é uma ciência significativa e influente e suas evoluções são frequentemente traduzidas no desenvolvimento de novas tecnologias. O avanço nos¶conhecimentos em eletromagnetismo permitiu o desenvolvimento de tecnologias que certamente influenciam o cotidiano da sociedade moderna: o domínio¶da energia elétrica permitiu o desenvolvimento e construção dos aparelhos elétricos; o domínio sobre as radiações eletromagnéticas e o controle refinado das¶correntes elétricas permitiu o surgimento da eletrônica e o consequente desenvolvimento das telecomunicações globais e da informática, que são indissociáveis da¶definição de sociedade civilizada contemporânea."),
            CriarGenercApresent(4, 410, "10", "Geral", 45, "Montreal possui uma das populações mais bem educadas do mundo, possuindo a maior concentração de estudantes universitários per capita de toda a América do Norte. A¶cidade possui quatro universidades - duas delas francófonas e duas delas anglófonas - e 12 faculdades. É um centro da indústria de alta tecnologia -¶especialmente na área de medicina e na indústria aeroespacial. Montreal é atualmente uma das cidades mais seguras do continente americano, sendo que em 2005¶foram cometidos apenas 35 homicídios em toda a cidade."),
            CriarGenercApresent(4, 411, "11", "Geral", 45, "Aos onze anos, João Figueiredo iniciou a carreira militar, obtendo o primeiro lugar no concurso para o Colégio Militar de Porto Alegre transferindo-se a¶seguir para o Colégio Militar do Rio de Janeiro. Ingressou, por fim, na Escola Militar do Realengo onde optou pela Cavalaria. Aos quarenta anos, trabalhou ao¶lado de Golbery do Couto e Silva no Estado-Maior do Exército e durante o curto governo de Jânio Quadros chefiou o Serviço Federal de Informações e foi¶secretário-geral do Conselho de Segurança Nacional. Iniciado o Regime Militar de 1964, foi lotado na agência fluminense do Serviço Nacional de Informações.¶Em 1969 foi promovido a General de Brigada e comandou o Estado-Maior do III Exército pouco antes de ser nomeado chefe do Gabinete Militar no governo Emílio Garrastazu¶Médici (1969-1974). Com a posse de Ernesto Geisel, foi nomeado ministro-chefe do SNI, cargo do qual se afastou para se candidatar a Presidência da¶República."),
            CriarGenercApresent(4, 412, "12", "Geral", 45, "A técnica básica de datilografia consiste em manter os pulsos erguidos, ao invés de apoiá-los sobre a mesa, pois isso pode causar síndrome do túnel carpal. O¶datilógrafo deve manter os cotovelos ao lado do corpo, levantar ligeiramente as mãos sobre o teclado. A maneira mais eficiente de datilografar é manter os¶olhos na tela do dispositivo, corrigindo possíveis erros mais rapidamente. Essa técnica se chama datilografia por toque. Quando não a utiliza, diz-que a¶pessoa está \"catando milho\". Atualmente, quase todo teclado possui marcas sobre as letras F e J, que servem para o datilógrafo encontrar a posição inicial de¶digitação apenas com o tato. Para pôr os dedos na posição inicial, basta colocar os dedos indicadores sobre as teclas marcadas, e os outros dedos sobre as¶teclas imediatamente vizinhas."),
            CriarGenercApresent(4, 413, "13", "Geral", 45, "René Descartes foi um filósofo, físico e matemático francês. Durante a Idade Moderna também era conhecido por seu nome latino Renatus Cartesius. Notabilizou-se¶sobretudo por seu trabalho revolucionário na filosofia e na ciência, mas também obteve reconhecimento matemático por sugerir a fusão da álgebra com a¶geometria - fato que gerou a geometria analítica e o sistema de coordenadas que hoje leva o seu nome. Por fim, ele foi uma das figuras-chave na Revolução¶Científica"),
            CriarGenercApresent(4, 414, "14", "Geral", 45, "Entre os indígenas do grupo, vigora um sistema de organização civil peculiar, caracterizado por um único complexo de imensas ocas comunitárias circularmente¶dispostas ao redor de um terreiro público. Tal espaço, formado a partir da convergência de quatro vias principais, destina-se à celebração dos ritos e¶tradições referentes à cosmologia do povo. As habitações, primordialmente constituídas por taquaras e palha, podem chegar a trinta metros de comprimento e¶abrigar várias famílias, segundo a ancestralidade que possuam."),
            CriarGenercApresent(4, 415, "15", "Geral", 45, "As rodas de pás possuem o formato de uma grande circunferência, com as lâminas ligadas em uma estrutura assemelhada a uma gaiola que atualmente é feita de aço.¶Uma parte das pás fica submersa. A rotação das pás faz com as mesmas se alternem naquelas que fiquem submersa, produzindo uma força de impulso que pode movimentar a¶embarcação para a frente e também para trás, se necessário. As rodas de construção mais avançada permitem que as lâminas fiquem próximas da vertical¶enquanto estão na água, aumentando a propulsão. A roda de pás geralmente é coberta, diminuindo os efeitos dos esguichos da água na embarcação."),
            CriarGenercApresent(4, 416, "16", "Geral", 45, "Há muito tempo busca-se um consenso quanto à definição do que é a matemática. No entanto, nas últimas décadas do século XX tomou forma uma definição que tem ampla¶aceitação entre os matemáticos: matemática é a ciência das regularidades (padrões). Segundo esta definição, o trabalho do matemático consiste em examinar padrões¶abstratos, tanto reais como imaginários, visuais ou mentais. Ou seja, os matemáticos procuram regularidades nos números, no espaço, na ciência e na imaginação e¶formulam teorias com as quais tentam explicar as relações observadas. Uma outra definição seria que matemática é a investigação de estruturas abstratas¶definidas axiomaticamente, usando a lógica formal como estrutura comum. As estruturas específicas geralmente têm sua origem nas ciências naturais, mais comumente na¶física, mas os matemáticos também definem e investigam estruturas por razões puramente internas à matemática (matemática pura), por exemplo, ao perceberem que as¶estruturas fornecem uma generalização unificante de vários subcampos ou uma ferramenta útil em cálculos comuns."),
            CriarGenercApresent(4, 417, "17", "Geral", 45, "Assim encontramos uma concepção \"clássica\", surgida durante o Iluminismo (que podemos chamar de \"definição moderna clássica\", que organiza e estabelece as bases¶de periodização usadas na estruturação do cânone ocidental); uma definição \"romântica\" (na qual a presença de uma intenção estética do próprio autor¶torna-se decisiva para essa caracterização); e, finalmente, uma concepção \"crítica\" (na qual as definições estáveis tornam-se passíveis de confronto, e¶a partir da qual se buscam modelos teóricos capazes de localizar o fenômeno literário e, apenas nesse movimento, \"defini-lo\"). Deixar a cargo do leitor¶individual a definição implica uma boa dose de subjetivismo, (postura identificada com a matriz romântica do conceito de \"Literatura\"); a menos que se¶queira ir às raias do solipsismo, encontrar-se-á alguma necessidade para um diálogo quanto a esta questão. Isto pode, entretanto, levar ao extremo oposto, de¶considerar como literatura apenas aquilo que é entendido como tal por toda a sociedade ou por parte dela, tida como autorizada à definição. Esta posição¶não só sufocaria a renovação na arte literária, como também limitaria excessivamente o corpus já reconhecido."),
            CriarGenercApresent(4, 418, "18", "Geral", 45, "Através do tempo, algumas formas especificas de esculturas foram mais utilizadas que outras: O busto, espécie de retrato do poderoso da época; a estátua¶eqüestre, tipicamente mostrando um poderoso senhor em seu cavalo; Fontes de água, especialmente em Roma, para coroar seus fabulosos aquedutos e onde a água corrente¶tinha um papel a representar; estátua, representando uma pessoa ou um deus em forma antropomórfica; Alto ou Baixo-relevo, o modo de ilustrar uma história em pedra¶ou metal ; mobiliário, normalmente utilizado em jardins."),
            CriarGenercApresent(4, 419, "19", "Geral", 45, "A humanidade cedo se percebeu das virtudes da associação de certas plantas aromáticas aos alimentos para lhes exaltar o sabor, contribuir para a sua¶conservação e permitir uma melhor e mais saudável assimilação por parte do corpo. Muitas guerras se fizeram pela apropriação de recursos alimentares que de¶uma forma geral são escassos e que determinam o poder para quem domina a gestão desses recursos. A título de exemplo, a busca das especiarias foi um dos fatores¶que contribuíram para a queda do Império Romano e quando a Europa parte para os Descobrimentos Marítimos tem como móbil o controle da rota das especiarias que¶implicou a colonização e o esclavagismo renascentistas"),
            CriarGenercApresent(4, 420, "20", "Geral", 45, "A moda é um sistema que acompanha o vestuário e o tempo, que integra o simples uso das roupas no dia-a-dia a um contexto maior, político, social,¶sociológico. Pode-se ver a moda naquilo que se escolhe de manhã para vestir, no look de um punk, de um skatista e de um pop star, nas passarelas. A cada dia¶que passa o mundo da moda vem se superando e surpreendendo as pessoas, com cores vivas, tendências novas, cortes inusitados e inovadores. A moda¶proporciona aos que seguem uma tendência sempre inovadora e ousada. Ela é abordada sempre, encaixa em qualquer assunto e é sempre um meio de inspiração aos¶que a seguem"),
            CriarGenercApresent(4, 421, "21", "Geral", 45, "De acordo com a primeira abordagem, a música existe antes de ser ouvida; ela pode mesmo ter uma existência autônoma na natureza e pela natureza. Os adeptos desse¶conceito afirmam que, em si mesma, a música não constitui arte, mas criá-la e expressá-la sim. Enquanto ouvir música possa ser um lazer e aprendê-la e¶entendê-la seja fruto da disciplina, a música em si é um fenômeno natural e universal. A teoria da ressonância natural de Mersenne e Rameau vai neste¶sentido, pois ao afirmar a natureza matemática das relações harmônicas e sua influência na percepção auditiva da consonância e dissonância, ela estabelece a¶preponderância do natural sobre a prática formal. Consideram ainda que, por ser um fenômeno natural e intuitivo, os seres humanos podem executar e ouvir a¶música virtualmente em suas mentes sem mesmo aprendê-la ou compreendê-la. Compor, improvisar e executar são formas de arte que utilizam o fenômeno música."),
            CriarGenercApresent(4, 422, "22", "Geral", 45, "Uma máquina automática com um controle de tempo por meio de um temporizador não pode ser considerada uma máquina automática programável, pois ela não muda seu¶trabalho conforme o ajuste do temporizador, muda apenas o período em que executa o trabalho. Também não pode ser considerada uma máquina automática programável uma¶máquina automática que possua um controle de intensidade que o usuário pode ajustar, pois assim ela também continua executando o mesmo trabalho apenas com¶uma intensidade diferente e seu trabalho não depende de programa algum."),
            CriarGenercApresent(4, 423, "23", "Geral", 45, "A França Metropolitana estende-se do Mediterrâneo ao Canal da Mancha e Mar do Norte, e do Rio Reno ao Oceano Atlântico. É muitas vezes referida como L'Hexagone¶por causa da forma geométrica do seu território e partilha fronteiras com a Bélgica e Luxemburgo a norte; Alemanha a nordeste; Suíça e Itália¶a leste; Espanha ao sul e com as micronações de Mônaco e Andorra. A nação é o maior país da União Europeia em área e o terceiro maior da Europa, atrás apenas da¶Rússia e da Ucrânia (incluindo seus territórios extraeuropeus, como a Guiana Francesa, o país torna-se maior que o território¶ucraniano)"),
            };

            return SetarPremiumPt(exerciciosPt, 402, premium); ;
        }
        public HashSet<LessonPresentation> MeusTextosApresentacao(bool premium)
        {
            var meusTextos = new HashSet<LessonPresentation>();

            // var textosBd = _exercicioRepository.MeusTextos(_userService.GetIdUsuario());
            // foreach (var exercText in textosBd)
            // {
            //     meusTextos.Add(CriarApresentMeustextos(exercText.Nome, exercText.Texto, exercText.IdentificadorExercicio));
            // }

            return SetarPremiumPt(meusTextos, meusTextos.First().IdentificadorExercicio, premium);
        }

        public LessonPresentation BuscarExercicio(int id)
        {
            var listasJuntas = new List<LessonPresentation>();
            listasJuntas.AddRange(InicianteApresentacaoPt(000));
            listasJuntas.AddRange(BasicoApresentacaoPt(true));
            listasJuntas.AddRange(IntermediarioApresentacaoPt(true));
            listasJuntas.AddRange(AvancadoApresentacaoPt(true));
            // listasJuntas.AddRange(MeusTextosApresentacao(true));

            return listasJuntas.FirstOrDefault(x => x.IdentificadorExercicio == id);
        }

        public void CriarMeuTexto(MeuTexto meuTexto)
        {
            meuTexto.Texto = TextoFormatacao.CriarExercicioComParagrafo(meuTexto.Texto, 55);
            //_exercicioRepository.AddMeuTexto(meuTexto);
        }

        public Resultado BuscarExercicioPorId()
        {
            var exerc = CriarInicianteBr().FirstOrDefault();
            return new Resultado
            {
                IdentificadorExercicio = exerc.IdentificadorExercicio,
                Nome = exerc.Nome,
                Texto = exerc.TextoFase,
                LetraErro = "",
                PPM = 0,
                PpmIdeal = exerc.PpmIdeal,
                TeclasEstudadas = exerc.TeclasEstudadas,
                Tempo = 0,
                TempoIdeal = exerc.TempoIdeal,
                Tentativas = 0,
                TotalErros = 0,
                TotalErrosIdeal = exerc.TotalErrosIdeal
            };
        }

        public static LessonPresentation CriarApresentMeustextos
            (string nome, string texto, int identExerc)
        {
            var tamTxt = texto.Length;
            return new LessonPresentation()
            {
                Categoria = 6,
                IdentificadorExercicio = identExerc,
                Nome = nome,
                PpmIdeal = tamTxt / 6,
                TeclasEstudadas = "Livre",
                TempoIdeal = tamTxt / 4,
                TextoFase = texto,
                TotalErrosIdeal = (int)(tamTxt * 0.02),
                Ativo = true
            };
        }

        public static HashSet<LessonPresentation> CriarInicianteBr()
        {
            return CriarListaInicianteGenerica("Iniciante", "Geral", EnumLingua.Pt,
                "q", "w", "e", "r", "t", "y", "u", "i", "o", "p", "a", "s", "d", "f", "g", "h", "j", "k", "l", "ç", "z", "x", "c", "v", "b", "n", "m", ",", ".", ";");
        }

        public static HashSet<LessonPresentation> CriarListaInicianteGenerica(string titulo, string geral, EnumLingua lingua,
         string q, string w, string e, string r, string t, string y, string u, string i, string o, string p, string a,
         string s, string d, string f, string g, string h, string j, string k, string l, string cc, string z, string x,
         string c, string v, string b, string n, string m, string vg, string pt, string ptv
         )
        {
            var exercicios = new HashSet<LessonPresentation>();

            exercicios.Add(CriarGenercApresent(1, 101, "01", $"{a}{s}{d}{f}{g}", 45, $"{a}{s}{d}{f}{g} {a}{s}{d}{f}{g} {h}{j}{k}{l}{cc} {h}{j}{k}{l}{cc} {a}{s}{d}{f}{g} {a}{s}{d}{f}{g} {h}{j}{k}{l}{cc} {h}{j}{k}{l}{cc} {a}{s}{d}{f}{g} {a}{s}{d}{f}{g} {h}{j}{k}{l}{cc} {h}{j}{k}{l}{cc}¶{a}{s}{d}{f}{g} {a}{s}{d}{f}{g} {h}{j}{k}{l}{cc} {h}{j}{k}{l}{cc} {a}{s}{d}{f}{g} {a}{s}{d}{f}{g} {h}{j}{k}{l}{cc} {h}{j}{k}{l}{cc} {a}{s}{d}{f}{g} {a}{s}{d}{f}{g} {h}{j}{k}{l}{cc} {h}{j}{k}{l}{cc}"));
            exercicios.Add(CriarGenercApresent(1, 102, "02", $"{a}{s}{d}{f}{g}", 45, $"{q}{w}{e}{r}{t} {q}{w}{e}{r}{t} {y}{u}{i}{o}{p} {y}{u}{i}{o}{p} {q}{w}{e}{r}{t} {q}{w}{e}{r}{t} {y}{u}{i}{o}{p} {y}{u}{i}{o}{p} {q}{w}{e}{r}{t} {q}{w}{e}{r}{t} {y}{u}{i}{o}{p} {y}{u}{i}{o}{p}¶{q}{w}{e}{r}{t} {q}{w}{e}{r}{t} {y}{u}{i}{o}{p} {y}{u}{i}{o}{p} {q}{w}{e}{r}{t} {q}{w}{e}{r}{t} {y}{u}{i}{o}{p} {y}{u}{i}{o}{p} {q}{w}{e}{r}{t} {q}{w}{e}{r}{t} {y}{u}{i}{o}{p} {y}{u}{i}{o}{p}"));
            exercicios.Add(CriarGenercApresent(1, 103, "03", $"{a}{s}{d}{f}{g}", 45, $"{z}{x}{c}{v}{b} {z}{x}{c}{v}{b} {n}{m}{vg}{pt}{ptv} {n}{m}{vg}{pt}{ptv} {z}{x}{c}{v}{b} {z}{x}{c}{v}{b} {n}{m}{vg}{pt}{ptv} {n}{m}{vg}{pt}{ptv} {z}{x}{c}{v}{b} {z}{x}{c}{v}{b} {n}{m}{vg}{pt}{ptv} {n}{m}{vg}{pt}{ptv}¶{z}{x}{c}{v}{b} {z}{x}{c}{v}{b} {n}{m}{vg}{pt}{ptv} {n}{m}{vg}{pt}{ptv} {z}{x}{c}{v}{b} {z}{x}{c}{v}{b} {n}{m}{vg}{pt}{ptv} {n}{m}{vg}{pt}{ptv} {z}{x}{c}{v}{b} {z}{x}{c}{v}{b} {n}{m}{vg}{pt}{ptv} {n}{m}{vg}{pt}{ptv}"));
            exercicios.Add(CriarGenercApresent(1, 104, "04", $"{a}{s}{d}{f}{g}", 45, $"{q}{w}{e}{r}{t} {a}{s}{d}{f}{g} {z}{x}{c}{v}{b} {y}{u}{i}{o}{p} {h}{j}{k}{l}{cc} {n}{m}{vg}{pt}{ptv} {q}{w}{e}{r}{t} {a}{s}{d}{f}{g} {z}{x}{c}{v}{b} {y}{u}{i}{o}{p} {h}{j}{k}{l}{cc} {n}{m}{vg}{pt}{ptv}¶{q}{w}{e}{r}{t} {a}{s}{d}{f}{g} {z}{x}{c}{v}{b} {y}{u}{i}{o}{p} {h}{j}{k}{l}{cc} {n}{m}{vg}{pt}{ptv} {q}{w}{e}{r}{t} {a}{s}{d}{f}{g} {z}{x}{c}{v}{b} {y}{u}{i}{o}{p} {h}{j}{k}{l}{cc} {n}{m}{vg}{pt}{ptv}"));
            exercicios.Add(CriarGenercApresent(1, 105, "05", $"{a}{s}{d}{f}{g}", 45, $"{z}{x}{c}{v}{b} {y}{u}{i}{o}{p} {a}{s}{d}{f}{g} {h}{j}{k}{l}{cc} {q}{w}{e}{r}{t} {n}{m}{vg}{pt}{ptv} {a}{s}{d}{f}{g} {h}{j}{k}{l}{cc} {z}{x}{c}{v}{b} {y}{u}{i}{o}{p} {a}{s}{d}{f}{g} {h}{j}{k}{l}{cc}¶{z}{x}{c}{v}{b} {y}{u}{i}{o}{p} {a}{s}{d}{f}{g} {h}{j}{k}{l}{cc} {q}{w}{e}{r}{t} {n}{m}{vg}{pt}{ptv} {a}{s}{d}{f}{g} {h}{j}{k}{l}{cc} {z}{x}{c}{v}{b} {y}{u}{i}{o}{p} {a}{s}{d}{f}{g} {h}{j}{k}{l}{cc}"));
            exercicios.Add(CriarGenercApresent(1, 106, "06", $"{a}{s}{d}{f}{g}", 45, $"{q}{w}{e}{r}{t}{y}{u}{i}{o}{p} {a}{s}{d}{f}{g}{h}{j}{k}{l}{cc} {z}{x}{c}{v}{b}{n}{m}{vg}{pt}{ptv} {q}{w}{e}{r}{t}{y}{u}{i}{o}{p} {a}{s}{d}{f}{g}{h}{j}{k}{l}{cc} {z}{x}{c}{v}{b}{n}{m}{vg}{pt}{ptv}¶{q}{w}{e}{r}{t}{y}{u}{i}{o}{p} {a}{s}{d}{f}{g}{h}{j}{k}{l}{cc} {z}{x}{c}{v}{b}{n}{m}{vg}{pt}{ptv} {q}{w}{e}{r}{t}{y}{u}{i}{o}{p} {a}{s}{d}{f}{g}{h}{j}{k}{l}{cc} {z}{x}{c}{v}{b}{n}{m}{vg}{pt}{ptv}"));
            exercicios.Add(CriarGenercApresent(1, 107, "07", $"{a}{s}{d}{f}{g}", 45, $"{q}{q} {u}{u} {a}{a} {j}{j} {z}{z} {m}{m} {w}{w} {i}{i} {s}{s} {k}{k} {x}{x} {vg}{vg} {e}{e} {o}{o} {d}{d} {l}{l} {c}{c} {pt}{pt} {r}{r} {p}{p} {f}{f} {cc}{cc} {v}{v} {ptv}{ptv}¶{q}{q} {u}{u} {a}{a} {j}{j} {z}{z} {m}{m} {w}{w} {i}{i} {s}{s} {k}{k} {x}{x} {vg}{vg} {e}{e} {o}{o} {d}{d} {l}{l} {c}{c} {pt}{pt} {r}{r} {p}{p} {f}{f} {cc}{cc} {v}{v} {ptv}{ptv}"));
            exercicios.Add(CriarGenercApresent(1, 108, "08", $"{a}{s}{d}{f}{g}", 45, $"{q}{w} {u}{i} {a}{s} {j}{k} {z}{x} {m}{vg} {w}{e} {i}{o} {s}{d} {k}{l} {x}{c} {vg}{pt} {e}{r} {o}{p} {d}{f} {l}{cc} {c}{v} {pt}{ptv} {q}{r} {u}{p} {a}{f} {j}{cc} {z}{v} {m}{ptv}¶{q}{w} {u}{i} {a}{s} {j}{k} {z}{x} {m}{vg} {w}{e} {i}{o} {s}{d} {k}{l} {x}{c} {vg}{pt} {e}{r} {o}{p} {d}{f} {l}{cc} {c}{v} {pt}{ptv} {q}{r} {u}{p} {a}{f} {j}{cc} {z}{v} {m}{ptv}"));
            exercicios.Add(CriarGenercApresent(1, 109, "09", $"{a}{s}{d}{f}{g}", 45, $"{q}{a}{z} {u}{j}{m} {w}{s}{x} {i}{k}{vg} {e}{d}{c} {o}{l}{pt} {r}{f}{v} {p}{cc}{ptv} {z}{a}{q} {m}{j}{u} {x}{s}{w} {vg}{k}{i} {c}{d}{e} {pt}{l}{o} {v}{f}{r} {ptv}{cc}{p} {q}{a}{z} {m}{j}{u}¶{q}{a}{z} {u}{j}{m} {w}{s}{x} {i}{k}{vg} {e}{d}{c} {o}{l}{pt} {r}{f}{v} {p}{cc}{ptv} {z}{a}{q} {m}{j}{u} {x}{s}{w} {vg}{k}{i} {c}{d}{e} {pt}{l}{o} {v}{f}{r} {ptv}{cc}{p} {q}{a}{z} {m}{j}{u}"));
            exercicios.Add(CriarGenercApresent(1, 110, "10", $"{a}{s}{d}{f}{g}", 45, $"{a}{w}{d}{r} {j}{i}{l}{p} {q}{s}{e}{f} {u}{k}{o}{cc} {a}{x}{d}{v} {j}{vg}{l}{ptv} {z}{s}{c}{f} {m}{k}{pt}{cc} {p}{l}{i}{j} {r}{d}{w}{a} {cc}{o}{k}{u} {f}{e}{s}{q} {v}{d}{x}{a} {ptv}{l}{vg}{j}¶{a}{w}{d}{r} {j}{i}{l}{p} {q}{s}{e}{f} {u}{k}{o}{cc} {a}{x}{d}{v} {j}{vg}{l}{ptv} {z}{s}{c}{f} {m}{k}{pt}{cc} {p}{l}{i}{j} {r}{d}{w}{a} {cc}{o}{k}{u} {f}{e}{s}{q} {v}{d}{x}{a} {ptv}{l}{vg}{j}"));
            exercicios.Add(CriarGenercApresent(1, 111, "11", $"{a}{s}{d}{f}{g}", 45, $"{q}{a} {w}{s} {e}{d} {r}{f} {t}{g} {y}{h} {u}{j} {i}{k} {o}{l} {p}{cc} {z}{a} {x}{s} {c}{d} {v}{f} {b}{g} {n}{h} {m}{j} {vg}{k} {pt}{l} {ptv}{cc} {a}{q} {j}{u} {d}{e} {k}{i}¶{q}{a} {w}{s} {e}{d} {r}{f} {t}{g} {y}{h} {u}{j} {i}{k} {o}{l} {p}{cc} {z}{a} {x}{s} {c}{d} {v}{f} {b}{g} {n}{h} {m}{j} {vg}{k} {pt}{l} {ptv}{cc} {a}{q} {j}{u} {d}{e} {k}{i}"));
            exercicios.Add(CriarGenercApresent(1, 112, "12", $"{a}{s}{d}{f}{g}", 45, $"{a}{w}{d}{r}{d}{w}{a} {a}{w}{d}{r}{d}{w}{a} {a}{w}{d}{r}{d}{w}{a} {a}{w}{d}{r}{d}{w}{a} {q}{s}{e}{f}{e}{s}{q} {q}{s}{e}{f}{e}{s}{q} {q}{s}{e}{f}{e}{s}{q} {q}{s}{e}{f}{e}{s}{q}¶{a}{w}{d}{r}{d}{w}{a} {a}{w}{d}{r}{d}{w}{a} {a}{w}{d}{r}{d}{w}{a} {a}{w}{d}{r}{d}{w}{a} {q}{s}{e}{f}{e}{s}{q} {q}{s}{e}{f}{e}{s}{q} {q}{s}{e}{f}{e}{s}{q} {q}{s}{e}{f}{e}{s}{q}"));
            exercicios.Add(CriarGenercApresent(1, 113, "13", $"{a}{s}{d}{f}{g}", 45, $"{j}{i}{l}{p}{l}{i}{j} {j}{i}{l}{p}{l}{i}{j} {j}{i}{l}{p}{l}{i}{j} {j}{i}{l}{p}{l}{i}{j} {u}{k}{o}{cc}{o}{k}{u} {u}{k}{o}{cc}{o}{k}{u} {u}{k}{o}{cc}{o}{k}{u} {u}{k}{o}{cc}{o}{k}{u}¶{j}{i}{l}{p}{l}{i}{j} {j}{i}{l}{p}{l}{i}{j} {j}{i}{l}{p}{l}{i}{j} {j}{i}{l}{p}{l}{i}{j} {u}{k}{o}{cc}{o}{k}{u} {u}{k}{o}{cc}{o}{k}{u} {u}{k}{o}{cc}{o}{k}{u} {u}{k}{o}{cc}{o}{k}{u}"));
            exercicios.Add(CriarGenercApresent(1, 114, "14", $"{a}{s}{d}{f}{g}", 45, $"{z}{s}{c}{f}{c}{s}{z} {z}{s}{c}{f}{c}{s}{z} {z}{s}{c}{f}{c}{s}{z} {z}{s}{c}{f}{c}{s}{z} {a}{x}{d}{v}{d}{x}{a} {a}{x}{d}{v}{d}{x}{a} {a}{x}{d}{v}{d}{x}{a} {a}{x}{d}{v}{d}{x}{a}¶{z}{s}{c}{f}{c}{s}{z} {z}{s}{c}{f}{c}{s}{z} {z}{s}{c}{f}{c}{s}{z} {z}{s}{c}{f}{c}{s}{z} {a}{x}{d}{v}{d}{x}{a} {a}{x}{d}{v}{d}{x}{a} {a}{x}{d}{v}{d}{x}{a} {a}{x}{d}{v}{d}{x}{a}"));
            exercicios.Add(CriarGenercApresent(1, 115, "15", $"{a}{s}{d}{f}{g}", 45, $"{m}{k}{pt}{cc}{pt}{k}{m} {m}{k}{pt}{cc}{pt}{k}{m} {m}{k}{pt}{cc}{pt}{k}{m} {m}{k}{pt}{cc}{pt}{k}{m} {j}{vg}{l}{ptv}{l}{vg}{j} {j}{vg}{l}{ptv}{l}{vg}{j} {j}{vg}{l}{ptv}{l}{vg}{j} {j}{vg}{l}{ptv}{l}{vg}{j}¶{m}{k}{pt}{cc}{pt}{k}{m} {m}{k}{pt}{cc}{pt}{k}{m} {m}{k}{pt}{cc}{pt}{k}{m} {m}{k}{pt}{cc}{pt}{k}{m} {j}{vg}{l}{ptv}{l}{vg}{j} {j}{vg}{l}{ptv}{l}{vg}{j} {j}{vg}{l}{ptv}{l}{vg}{j} {j}{vg}{l}{ptv}{l}{vg}{j}"));
            exercicios.Add(CriarGenercApresent(1, 116, "16", $"{a}{s}{d}{f}{g}", 45, $"{a}{w}{z}{s}{d}{r} {a}{w}{z}{s}{d}{r} {a}{w}{z}{s}{d}{r} {a}{w}{z}{s}{d}{r} {a}{w}{z}{s}{d}{r} {j}{i}{m}{k}{l}{p} {j}{i}{m}{k}{l}{p} {j}{i}{m}{k}{l}{p} {j}{i}{m}{k}{l}{p} {j}{i}{m}{k}{l}{p}¶{a}{w}{z}{s}{d}{r} {a}{w}{z}{s}{d}{r} {a}{w}{z}{s}{d}{r} {a}{w}{z}{s}{d}{r} {a}{w}{z}{s}{d}{r} {j}{i}{m}{k}{l}{p} {j}{i}{m}{k}{l}{p} {j}{i}{m}{k}{l}{p} {j}{i}{m}{k}{l}{p} {j}{i}{m}{k}{l}{p}"));
            exercicios.Add(CriarGenercApresent(1, 117, "17", $"{a}{s}{d}{f}{g}", 45, $"{q}{s}{e}{f}{a}{w}{d}{r} {q}{s}{e}{f}{a}{w}{d}{r} {q}{s}{e}{f}{a}{w}{d}{r} {q}{s}{e}{f}{a}{w}{d}{r} {q}{s}{e}{f}{a}{w}{d}{r} {q}{s}{e}{f}{a}{w}{d}{r} {q}{s}{e}{f}{a}{w}{d}{r} {q}{s}{e}{f}{a}{w}{d}{r}¶{q}{s}{e}{f}{a}{w}{d}{r} {q}{s}{e}{f}{a}{w}{d}{r} {q}{s}{e}{f}{a}{w}{d}{r} {q}{s}{e}{f}{a}{w}{d}{r} {q}{s}{e}{f}{a}{w}{d}{r} {q}{s}{e}{f}{a}{w}{d}{r} {q}{s}{e}{f}{a}{w}{d}{r} {q}{s}{e}{f}{a}{w}{d}{r}"));
            exercicios.Add(CriarGenercApresent(1, 118, "18", $"{a}{s}{d}{f}{g}", 45, $"{u}{k}{o}{cc}{j}{i}{l}{p} {u}{k}{o}{cc}{j}{i}{l}{p} {u}{k}{o}{cc}{j}{i}{l}{p} {u}{k}{o}{cc}{j}{i}{l}{p} {u}{k}{o}{cc}{j}{i}{l}{p} {u}{k}{o}{cc}{j}{i}{l}{p} {u}{k}{o}{cc}{j}{i}{l}{p} {u}{k}{o}{cc}{j}{i}{l}{p}¶{u}{k}{o}{cc}{j}{i}{l}{p} {u}{k}{o}{cc}{j}{i}{l}{p} {u}{k}{o}{cc}{j}{i}{l}{p} {u}{k}{o}{cc}{j}{i}{l}{p} {u}{k}{o}{cc}{j}{i}{l}{p} {u}{k}{o}{cc}{j}{i}{l}{p} {u}{k}{o}{cc}{j}{i}{l}{p} {u}{k}{o}{cc}{j}{i}{l}{p}"));
            exercicios.Add(CriarGenercApresent(1, 119, "19", $"{a}{s}{d}{f}{g}", 45, $"{a}{x}{d}{v}{z}{s}{c}{f} {a}{x}{d}{v}{z}{s}{c}{f} {a}{x}{d}{v}{z}{s}{c}{f} {a}{x}{d}{v}{z}{s}{c}{f} {a}{x}{d}{v}{z}{s}{c}{f} {a}{x}{d}{v}{z}{s}{c}{f} {a}{x}{d}{v}{z}{s}{c}{f} {a}{x}{d}{v}{z}{s}{c}{f}¶{a}{x}{d}{v}{z}{s}{c}{f} {a}{x}{d}{v}{z}{s}{c}{f} {a}{x}{d}{v}{z}{s}{c}{f} {a}{x}{d}{v}{z}{s}{c}{f} {a}{x}{d}{v}{z}{s}{c}{f} {a}{x}{d}{v}{z}{s}{c}{f} {a}{x}{d}{v}{z}{s}{c}{f} {a}{x}{d}{v}{z}{s}{c}{f}"));
            exercicios.Add(CriarGenercApresent(1, 120, "20", $"{a}{s}{d}{f}{g}", 45, $"{j}{vg}{l}{ptv} {m}{k}{pt}{cc} {j}{vg}{l}{ptv} {m}{k}{pt}{cc} {j}{vg}{l}{ptv} {m}{k}{pt}{cc} {j}{vg}{l}{ptv} {m}{k}{pt}{cc} {j}{vg}{l}{ptv} {m}{k}{pt}{cc} {j}{vg}{l}{ptv} {m}{k}{pt}{cc} {j}{vg}{l}{ptv} {m}{k}{pt}{cc}¶{j}{vg}{l}{ptv} {m}{k}{pt}{cc} {j}{vg}{l}{ptv} {m}{k}{pt}{cc} {j}{vg}{l}{ptv} {m}{k}{pt}{cc} {j}{vg}{l}{ptv} {m}{k}{pt}{cc} {j}{vg}{l}{ptv} {m}{k}{pt}{cc} {j}{vg}{l}{ptv} {m}{k}{pt}{cc} {j}{vg}{l}{ptv} {m}{k}{pt}{cc}"));
            exercicios.Add(CriarGenercApresent(1, 121, "21", $"{a}{s}{d}{f}{g}", 45, $"{q}{s}{a}{w}{e}{f}{d}{r} {q}{s}{a}{w}{e}{f}{d}{r} {q}{s}{a}{w}{e}{f}{d}{r} {q}{s}{a}{w}{e}{f}{d}{r} {q}{s}{a}{w}{e}{f}{d}{r} {q}{s}{a}{w}{e}{f}{d}{r} {q}{s}{a}{w}{e}{f}{d}{r} {q}{s}{a}{w}{e}{f}{d}{r}¶{q}{s}{a}{w}{e}{f}{d}{r} {q}{s}{a}{w}{e}{f}{d}{r} {q}{s}{a}{w}{e}{f}{d}{r} {q}{s}{a}{w}{e}{f}{d}{r} {q}{s}{a}{w}{e}{f}{d}{r} {q}{s}{a}{w}{e}{f}{d}{r} {q}{s}{a}{w}{e}{f}{d}{r} {q}{s}{a}{w}{e}{f}{d}{r}"));
            exercicios.Add(CriarGenercApresent(1, 122, "22", $"{a}{s}{d}{f}{g}", 45, $"{u}{k}{j}{i}{o}{cc}{l}{p} {u}{k}{j}{i}{o}{cc}{l}{p} {u}{k}{j}{i}{o}{cc}{l}{p} {u}{k}{j}{i}{o}{cc}{l}{p} {u}{k}{j}{i}{o}{cc}{l}{p} {u}{k}{j}{i}{o}{cc}{l}{p} {u}{k}{j}{i}{o}{cc}{l}{p} {u}{k}{j}{i}{o}{cc}{l}{p}¶{u}{k}{j}{i}{o}{cc}{l}{p} {u}{k}{j}{i}{o}{cc}{l}{p} {u}{k}{j}{i}{o}{cc}{l}{p} {u}{k}{j}{i}{o}{cc}{l}{p} {u}{k}{j}{i}{o}{cc}{l}{p} {u}{k}{j}{i}{o}{cc}{l}{p} {u}{k}{j}{i}{o}{cc}{l}{p} {u}{k}{j}{i}{o}{cc}{l}{p}"));
            exercicios.Add(CriarGenercApresent(1, 123, "23", $"{a}{s}{d}{f}{g}", 45, $"{a}{x}{z}{s}{d}{v}{c}{f} {a}{x}{z}{s}{d}{v}{c}{f} {a}{x}{z}{s}{d}{v}{c}{f} {a}{x}{z}{s}{d}{v}{c}{f} {a}{x}{z}{s}{d}{v}{c}{f} {a}{x}{z}{s}{d}{v}{c}{f} {a}{x}{z}{s}{d}{v}{c}{f} {a}{x}{z}{s}{d}{v}{c}{f}¶{a}{x}{z}{s}{d}{v}{c}{f} {a}{x}{z}{s}{d}{v}{c}{f} {a}{x}{z}{s}{d}{v}{c}{f} {a}{x}{z}{s}{d}{v}{c}{f} {a}{x}{z}{s}{d}{v}{c}{f} {a}{x}{z}{s}{d}{v}{c}{f} {a}{x}{z}{s}{d}{v}{c}{f} {a}{x}{z}{s}{d}{v}{c}{f}"));
            exercicios.Add(CriarGenercApresent(1, 124, "24", $"{a}{s}{d}{f}{g}", 45, $"{j}{vg}{m}{k}{l}{ptv}{pt}{cc} {j}{vg}{m}{k}{l}{ptv}{pt}{cc} {j}{vg}{m}{k}{l}{ptv}{pt}{cc} {j}{vg}{m}{k}{l}{ptv}{pt}{cc} {j}{vg}{m}{k}{l}{ptv}{pt}{cc} {j}{vg}{m}{k}{l}{ptv}{pt}{cc} {j}{vg}{m}{k}{l}{ptv}{pt}{cc} {j}{vg}{m}{k}{l}{ptv}{pt}{cc}¶{j}{vg}{m}{k}{l}{ptv}{pt}{cc} {j}{vg}{m}{k}{l}{ptv}{pt}{cc} {j}{vg}{m}{k}{l}{ptv}{pt}{cc} {j}{vg}{m}{k}{l}{ptv}{pt}{cc} {j}{vg}{m}{k}{l}{ptv}{pt}{cc} {j}{vg}{m}{k}{l}{ptv}{pt}{cc} {j}{vg}{m}{k}{l}{ptv}{pt}{cc} {j}{vg}{m}{k}{l}{ptv}{pt}{cc}"));
            exercicios.Add(CriarGenercApresent(1, 125, "25", $"{a}{s}{d}{f}{g}", 45, $"{a}{w}{a}{s}{a}{e}{a}{d}{a}{r}{a}{f} {a}{w}{a}{s}{a}{e}{a}{d}{a}{r}{a}{f} {a}{w}{a}{s}{a}{e}{a}{d}{a}{r}{a}{f} {a}{w}{a}{s}{a}{e}{a}{d}{a}{r}{a}{f}¶{a}{w}{a}{s}{a}{e}{a}{d}{a}{r}{a}{f} {a}{w}{a}{s}{a}{e}{a}{d}{a}{r}{a}{f} {a}{w}{a}{s}{a}{e}{a}{d}{a}{r}{a}{f} {a}{w}{a}{s}{a}{e}{a}{d}{a}{r}{a}{f}"));
            exercicios.Add(CriarGenercApresent(1, 126, "26", $"{a}{s}{d}{f}{g}", 45, $"{j}{i}{j}{k}{j}{o}{j}{l}{j}{p}{j}{cc} {j}{i}{j}{k}{j}{o}{j}{l}{j}{p}{j}{cc} {j}{i}{j}{k}{j}{o}{j}{l}{j}{p}{j}{cc} {j}{i}{j}{k}{j}{o}{j}{l}{j}{p}{j}{cc}¶{j}{i}{j}{k}{j}{o}{j}{l}{j}{p}{j}{cc} {j}{i}{j}{k}{j}{o}{j}{l}{j}{p}{j}{cc} {j}{i}{j}{k}{j}{o}{j}{l}{j}{p}{j}{cc} {j}{i}{j}{k}{j}{o}{j}{l}{j}{p}{j}{cc}"));
            exercicios.Add(CriarGenercApresent(1, 127, "27", $"{a}{s}{d}{f}{g}", 45, $"{f}{e}{f}{d}{f}{w}{f}{s}{f}{q}{f}{a} {f}{e}{f}{d}{f}{w}{f}{s}{f}{q}{f}{a} {f}{e}{f}{d}{f}{w}{f}{s}{f}{q}{f}{a} {f}{e}{f}{d}{f}{w}{f}{s}{f}{q}{f}{a}¶{f}{e}{f}{d}{f}{w}{f}{s}{f}{q}{f}{a} {f}{e}{f}{d}{f}{w}{f}{s}{f}{q}{f}{a} {f}{e}{f}{d}{f}{w}{f}{s}{f}{q}{f}{a} {f}{e}{f}{d}{f}{w}{f}{s}{f}{q}{f}{a}"));
            exercicios.Add(CriarGenercApresent(1, 128, "28", $"{a}{s}{d}{f}{g}", 45, $"{cc}{o}{cc}{l}{cc}{i}{cc}{k}{cc}{u}{cc}{j} {cc}{o}{cc}{l}{cc}{i}{cc}{k}{cc}{u}{cc}{j} {cc}{o}{cc}{l}{cc}{i}{cc}{k}{cc}{u}{cc}{j} {cc}{o}{cc}{l}{cc}{i}{cc}{k}{cc}{u}{cc}{j}¶{cc}{o}{cc}{l}{cc}{i}{cc}{k}{cc}{u}{cc}{j} {cc}{o}{cc}{l}{cc}{i}{cc}{k}{cc}{u}{cc}{j} {cc}{o}{cc}{l}{cc}{i}{cc}{k}{cc}{u}{cc}{j} {cc}{o}{cc}{l}{cc}{i}{cc}{k}{cc}{u}{cc}{j}"));
            exercicios.Add(CriarGenercApresent(1, 129, "29", $"{a}{s}{d}{f}{g}", 45, $"{s}{q}{s}{e}{s}{a}{s}{f}{s}{z}{s}{v} {s}{q}{s}{e}{s}{a}{s}{f}{s}{z}{s}{v} {s}{q}{s}{e}{s}{a}{s}{f}{s}{z}{s}{v} {s}{q}{s}{e}{s}{a}{s}{f}{s}{z}{s}{v}¶{s}{q}{s}{e}{s}{a}{s}{f}{s}{z}{s}{v} {s}{q}{s}{e}{s}{a}{s}{f}{s}{z}{s}{v} {s}{q}{s}{e}{s}{a}{s}{f}{s}{z}{s}{v} {s}{q}{s}{e}{s}{a}{s}{f}{s}{z}{s}{v}"));
            exercicios.Add(CriarGenercApresent(1, 130, "30", $"{a}{s}{d}{f}{g}", 45, $"{k}{o}{k}{u}{k}{cc}{k}{j}{k}{ptv}{k}{m} {k}{o}{k}{u}{k}{cc}{k}{j}{k}{ptv}{k}{m} {k}{o}{k}{u}{k}{cc}{k}{j}{k}{ptv}{k}{m} {k}{o}{k}{u}{k}{cc}{k}{j}{k}{ptv}{k}{m}¶{k}{o}{k}{u}{k}{cc}{k}{j}{k}{ptv}{k}{m} {k}{o}{k}{u}{k}{cc}{k}{j}{k}{ptv}{k}{m} {k}{o}{k}{u}{k}{cc}{k}{j}{k}{ptv}{k}{m} {k}{o}{k}{u}{k}{cc}{k}{j}{k}{ptv}{k}{m}"));
            exercicios.Add(CriarGenercApresent(1, 131, "31", $"{a}{s}{d}{f}{g}", 45, $"{d}{r}{d}{q}{d}{f}{d}{a}{d}{v}{d}{z} {d}{r}{d}{q}{d}{f}{d}{a}{d}{v}{d}{z} {d}{r}{d}{q}{d}{f}{d}{a}{d}{v}{d}{z} {d}{r}{d}{q}{d}{f}{d}{a}{d}{v}{d}{z}¶{d}{r}{d}{q}{d}{f}{d}{a}{d}{v}{d}{z} {d}{r}{d}{q}{d}{f}{d}{a}{d}{v}{d}{z} {d}{r}{d}{q}{d}{f}{d}{a}{d}{v}{d}{z} {d}{r}{d}{q}{d}{f}{d}{a}{d}{v}{d}{z}"));
            exercicios.Add(CriarGenercApresent(1, 132, "32", $"{a}{s}{d}{f}{g}", 45, $"{l}{p}{l}{u}{l}{cc}{l}{j}{l}{ptv}{l}{m} {l}{p}{l}{u}{l}{cc}{l}{j}{l}{ptv}{l}{m} {l}{p}{l}{u}{l}{cc}{l}{j}{l}{ptv}{l}{m} {l}{p}{l}{u}{l}{cc}{l}{j}{l}{ptv}{l}{m}¶{l}{p}{l}{u}{l}{cc}{l}{j}{l}{ptv}{l}{m} {l}{p}{l}{u}{l}{cc}{l}{j}{l}{ptv}{l}{m} {l}{p}{l}{u}{l}{cc}{l}{j}{l}{ptv}{l}{m} {l}{p}{l}{u}{l}{cc}{l}{j}{l}{ptv}{l}{m}"));

            return exercicios;
        }

        public static LessonPresentation CriarGenercApresent
            (int categoria, int identExerc, string numTitulo, string teclasEstudadas, int ppmIdeal, string txtFase)
        {
            var tamTxt = txtFase.Length;
            return new LessonPresentation()
            {
                Categoria = categoria,
                IdentificadorExercicio = identExerc,
                Nome = numTitulo,
                PpmIdeal = ppmIdeal,
                TeclasEstudadas = teclasEstudadas,
                TempoIdeal = tamTxt / 4,
                TextoFase = txtFase,
                TotalErrosIdeal = (int)(tamTxt * 0.02),
                Ativo = true
            };
        }

        private HashSet<LessonPresentation> SetarPremiumPt(HashSet<LessonPresentation> exApresLista, int limite, bool premium)
        {
            if (!premium)
            {
                exApresLista.ToList().ForEach(exc =>
                {
                    if (exc.IdentificadorExercicio > limite)
                    {
                        exc.Premium = true;
                        exc.LinkItem = "/Cobranca";
                    }
                    else
                    {
                        exc.LinkItem =
                            $"/curso-de-digitacao/pt/nivel/{exc.Categoria}/licao/{exc.IdentificadorExercicio}";
                    }
                });
            }
            else
            {
                exApresLista.ToList().ForEach(exc =>
                {
                    exc.LinkItem =
                        $"/curso-de-digitacao/pt/nivel/{exc.Categoria}/licao/{exc.IdentificadorExercicio}";
                });
            }

            return exApresLista;
        }
    }

}
