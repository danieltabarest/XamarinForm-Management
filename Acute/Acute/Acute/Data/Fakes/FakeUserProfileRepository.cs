using System;
using System.Threading.Tasks;
using Acute.Data.Interfaces;
using Acute.Models;

namespace Acute.Data.Fakes
{
    public class FakeUserProfileRepository : IUserProfileRepository
    {
        public FakeUserProfileRepository()
        {
        }

        public async Task<string> GetProfileImageAsync()
        {
            await Task.Delay(1000);
            return "/9j/4AAQSkZJRgABAgAAAQABAAD/2wBDAAUDBAQEAwUEBAQFBQUGBwwIBwc" +
                "HBw8KCwkMEQ8SEhEPERATFhwXExQaFRARGCEYGhwdHx8fExciJCIeJBweHx7/2" +
                "wBDAQUFBQcGBw4ICA4eFBEUHh4eHh4eHh4eHh4eHh4eHh4eHh4eHh4eHh4eHh4" +
                "eHh4eHh4eHh4eHh4eHh4eHh4eHh7/wAARCADIAMgDASIAAhEBAxEB/8QAHwAAA" +
                "QUBAQEBAQEAAAAAAAAAAAECAwQFBgcICQoL/8QAtRAAAgEDAwIEAwUFBAQAAAF" +
                "9AQIDAAQRBRIhMUEGE1FhByJxFDKBkaEII0KxwRVS0fAkM2JyggkKFhcYGRolJ" +
                "icoKSo0NTY3ODk6Q0RFRkdISUpTVFVWV1hZWmNkZWZnaGlqc3R1dnd4eXqDhIW" +
                "Gh4iJipKTlJWWl5iZmqKjpKWmp6ipqrKztLW2t7i5usLDxMXGx8jJytLT1NXW1" +
                "9jZ2uHi4+Tl5ufo6erx8vP09fb3+Pn6/8QAHwEAAwEBAQEBAQEBAQAAAAAAAAE" +
                "CAwQFBgcICQoL/8QAtREAAgECBAQDBAcFBAQAAQJ3AAECAxEEBSExBhJBUQdhc" +
                "RMiMoEIFEKRobHBCSMzUvAVYnLRChYkNOEl8RcYGRomJygpKjU2Nzg5OkNERUZ" +
                "HSElKU1RVVldYWVpjZGVmZ2hpanN0dXZ3eHl6goOEhYaHiImKkpOUlZaXmJmao" +
                "qOkpaanqKmqsrO0tba3uLm6wsPExcbHyMnK0tPU1dbX2Nna4uPk5ebn6Onq8vP" +
                "09fb3+Pn6/9oADAMBAAIRAxEAPwDwmKP2q3BHzToYeOlXIIPavqYxPClIbHHVu" +
                "CPpxUkUHTir0MHPStkjGTK6xe1WI4qtx2/tViO39q1SMZMprD7U5Yj6VopbDHS" +
                "pFtvatYpGEmZywcU4Qe1aiW3tUi23tW0Ujnk2ZQhPHFOEJ9K1hbDPSpEsnf7q5" +
                "rTRK7Mfek7IxxAfSnC39q2WsZUGWjbHrimi3B6CqjKMtmROE4/ErGR9nOelL9m" +
                "9q2Ps2eoo+ze1WQY32Y+lIbXjpW19m9qT7N7UmUjFNt7U02uO1bZtvamNb8dKh" +
                "mkTDe27YqGS256Vuvb8YxVeS361lI3iYUlv2xVWW368VvSwe1VJYOvFZSN4mBL" +
                "B14orSmg46UVkzRGZDD04q9DB04qWCDgcVdgg6cVyo7WRwwZxxV2CDpxUsUPtV" +
                "2GEccVqkYyIY4farMcGe1WYoRxxVmOEdhW0UYSZTWDtipVhOelXkh9qkWD2raK" +
                "MJMpLD2xTL2SCyt2uJztVa1fK2gnaTjsBk1V8PaD/AG9rcl7qG77DaPhIT/Ew9" +
                "a5Mwx8MFS55b9EdWX5fPHVeSO3VlrwtoV9rccV48TW1qwyN4wzfhXZp4RQ2+2I" +
                "YI/Wui0uFVhCqNpA4B4FdJY2QkTLADA4Ir4DFZliMZL35aduh+h4TLsNgo+5HX" +
                "v1PPT4XmRGJVStc9q/h1SoChopAcb0/qK9pa3VBh+R3FcrrUCHe46Dr2rClWq0" +
                "Jc0JWZ1Tp0sRHlqRTR45crPp1wkOobfLc7UmXgE+h9DVsQVd8XRrJA8UgDo/BD" +
                "DINZHhe6MryWErFnjG5CTnK/wD1q+4yXOnin7Gt8XR9z4DPsiWE/fUPh6rt/wA" +
                "AteQcdKaYPatcQcdKaYPavpT5ZMyDD7UxoOOla7Qe1MeA46VLRomYskHtVeWH2" +
                "rckg9qry2/tWbRtFmDLD7VTmhrfmt/aqc0HtWLRvFnPzQ8HiitOeDrxRWTRujL" +
                "t4var8MHTAot4enFX4YulcqR1SY2KH2q1FF0qWGLirMcXPStoowlIZFF7VZjj6" +
                "VLDFVlIumK2ijCTIo4qmWLnpViKLpUyxc1tFHPJkNrEBJvcfIqlm56ACtHwqY1" +
                "sMjA8xi/15qCaBzp9w0ZwygDHrmodAaXbBAEywGT2r5DiNudTl7I+v4aXLTcu7" +
                "O50+XcQOvGDXR2l5KIAViJ28cVxlnlZypO35c1u2Gqtbjay8f7w6fSvk43Uj7B" +
                "rmiasjSzKdzMq554rm9faUwOsO0qO2K17rxBYzBI0A3HJI7jFcvq+u2rQH7Oqu" +
                "7g+h74rRjimuhwWvLKsgDnCjnrXOWMv2HV4booSu/DH0B610OqrdXUjtMIo0HQ" +
                "K4NYOp24axRhkktg4OK7cvbp1VJbrU8/M4qpRcHszv1jyM4oMVO0QmfSbWVvvN" +
                "GM59aumL2r9PjUUop9z8mlTcZOL6GcYvao3iFaRh9qjeL2p3EkZjxe1V5IvatV" +
                "4vaoJYuKhmsTGmhz2qnND14rblix2qnNF7VkzeLMK4hoq/PFRWTN0zJgj5FXYY" +
                "8Y4qKBeavwqOK5kdMh8MfAqxGnNEK8YqzGlbRMZCxp3qwidKSNanRelaxMZDo1" +
                "qxGuaYi8cVPGpFapmEiWAxxpKZBlfl/nUmhacIrqW5kXkjcoPYV5v4z8XeJdH8" +
                "bR6atvHdaPNCDsCYZfUg9zmvWdKuINU0OPWbM/upIQrkfwuByPwr4jNcUq9ael" +
                "nHT7j7zKsC8NQptyupK/39DjPiT4rtPD7QvNdxwqcg7eT+ArxfXfH019qhn0rU" +
                "79gASVMeNoB5zzkfjXvGueBtH1GcavJYDULj+63OD64NQeHvhitzfyTR+G7Kyil" +
                "JM08oyzA9eO9eNCpCWvU93lnG1uhzfwMv9V8VXt9cSu0y28W1QMg5YV5l8Xte8Q" +
                "aL4qfQ7WSeIHG1QeSSema+rvB+l6Zo2sPaadbRwxLGQ5VANxA68V514g02y1Pxj" +
                "LdyRRLLKxCMVBxg+9TC1+Y2qOT02Pm/SvGuq22bKSSaWVj85dvuEcda9X0O+h1b" +
                "w7BJC5Z2QM4Y/MCeuR+dXPFHhPXYdTSe202ymVXDCRTtbg8ZBo8P2H2S9naSFVl" +
                "cbnRM447CuylVg5WXU8/EUaij7zueheGDbyaNClvMkwizGxXswPIrU2Vi/Duykt" +
                "fCdm86FJ7oG5kU/wl+Qv4DA/CuiIFff4aT9jG/ZH5pioRVaajtdlUpzUbp7VbZa" +
                "jcV0cxhylJ0qvIlX3X2qu680NjSM6VKpzJzWpKnWqkqVDNYmTMntRVidetFZM2R" +
                "iQqM1diXiq0PWrsQrnR0yJ4VqzGvFRQjirEVaoykSRrU6DFMQVMBitEzFkkfFTq" +
                "MioEqZDitEzKSK+o6VBqAJkQGVY2WNu4J6VsfDK0ms/Al/plxG6PEGZixydxyxN" +
                "U3jSWJopBlXGCM4rc8Iy28Go32n3F0rG5t/3URIyI1ONxPfrXyWc4RU8Uqq2krP" +
                "1Ps8jxrq4N0W9YNNehW8P3q2pDzOAvYHvWf4v+Jj29ymj6JGbi8mOAEGdo7sfYV" +
                "znja9u4ri6htQR5W7p6VV8C3uieH4915JE+qXK7rmVyNy5/hHoBXy0YcsnFH2EH" +
                "FxUmjoYvHnh/w5f7NQ1gTSSRZLtxk964DxJr2heJtQmvdF1r7Nd2xLW8ZfYkvcg" +
                "+uelcB8WfBeiy6lcan4e1+3knlkL+R9oU7M8nHPFedaRpMVrrMU+pahGro4YnzN" +
                "xOK7KcI2MatSfNpH5n0lYePnk8yy1KA210g5RjnPuD3FMvpYptPv76DD77SXaB1" +
                "3bTivPtX8R6TrjwWcVwkl5FtCSpzwTyM967XwHbSqk2mXBBO4ofcGnh6f72xjjq" +
                "i9jzLoeneHzOdB083IxObWPzR6NtGf1q/ikUYAAGAKGr9GguWKR+UzfPJy7jWqN" +
                "ulPNMPNWTYifgVA45qw9QuKAsVZRxVOYc1el6VUkHepbNIoz5l5NFSTiis2zVIw" +
                "IRyKux9Kpw8VdiPHNc6OqRPCatxYzVWPtVmIitIsyki1HUwFQRmrC8itEzFocgq" +
                "ReMUxRUgq0zNolQ5p0EcVtLc6jBBGLoQHMgX5iBzjNMQ4q5puxpZFkGUMTbh7Yr" +
                "DGJOhK/Zm+CbWIhZ7tHAX2qrPrUrk5FwSWOfXtWHr/w08O6gkuo39/qQaVtzPDN" +
                "jYOvToRVLxpHcafdPdQ5cQyHOPTNdV4a1yx1TToxcTAZXHWvzupFwm5I/T6E1OC" +
                "izz278GeA7FGK+K4WyCNt1F8wz9DXM6l4f8Dl0hGu+fjC/uItufqTXr+p+FvB7F" +
                "ru8kSQNzuLDArktY0rwMkzPbqFSIfe3gDNaKb7m8qcX0Mnwx4U8N6TqMU0Nur7H" +
                "DqznccCu4+H9wt/r+IhuYymSQ+gBz/hXGXer2SWO2A7g3CDHNelfBzS0sdCkupE" +
                "/0mZ/mJ6gdhXoZZh3WxMWzwc4xSo4WSivI9C3CkJFQ7qQvX3Fj89JWIqNiKYWpr" +
                "txT2GDsKhkOKVmqJzSbGkRymq0p4qaQ4FVpW4qGzRIrTHrRTJTRUNmqRiRVai6Y" +
                "qnCc4q1Ga50dDLUbdKtRHiqaH5asRNWkWZtFxDU6NyKqRtUyt3rRMyaLasKkDCs" +
                "+5vLezgNxdzxW8S9XkYKB+dcxqfxK8MWQby7iS7Yf88U4P4mm5pbkqlKeyO5Dc1p" +
                "eGbVtYu9VsrMNLd2liZdijPJ4UfU4OBXisvxZnkfNppCRxdmmkOfyFfRn7M7RXP" +
                "w+uddOxrrUL6RpZFHJC4VR9AP51w4/EJUGo9dDuwWElGtGUump4H4qYMZo3HJBD" +
                "D3ryk31zYvLAsjBckjBxX1t8bPhm+refr/AIbhzdnL3Vov/LT1ZB6+o718r6/p/" +
                "ls7FCrAnII6GvjJOVN8sj7yi41Y88Gc9eazfmJo/ttxsPYNxWbPLPfFRNNJsToM" +
                "4FRXrFJWUnNUTdGNslgBnNUrCnOVtWd74YjiE6XM5ysQyoPPSvYfA3ii1tINOtL" +
                "sGNNTmeK2k/hMoGSv9B7ivG/Bmj3usrGs++2ss5dj8rSD0HoK3Pjvq1np2g+HdJ" +
                "0uRYZrK5E6mM48sqOPx716uBcqMlUPEzHkrw9kfRBem76+TIPjj47gui32y1uog" +
                "cBZbccj6jFd94S+PtrdMsPiDSmt26Ga2O4fip5r6KnmFKbtc+Ynl1aCva57ru46" +
                "01mxWRoHiDR9etftOkX8N2g+8FPzL9V6itEtXWpJ6nI4NOzHM2ajYmgtTHak2Uk" +
                "MdqrSkVJIetV5DUNlpEMp5oqOU0VJZh27dqtoazoG561djfNYJnQy4jcVNG2a86" +
                "+IHji50G7Wy0+GKSXbukMmTtz0xXAX3jTxZfMQ2qSQof4YQE/lzQ6iRcaEpan0B" +
                "qeqafpVubjULyK2jHTe2CfoOprz/wAQfFNiWg0C2BHT7ROP1C/415XI81zJ5l1N" +
                "LcOerSMSamBHQYFJ1W9jSOGitXqaOp6nqWrXBn1O9kuZOwZuF+i9BVOaUrtjTOT" +
                "UYb9PeoInLSM7cjt7VDZ0RXY0vM3RlMnkYNfW/wCxhrCXvgrVtEZwZLG7EqL/AL" +
                "Lr/itfHTTLGOPvGvob9ie4eLx9q26XEMunqsmTgEhsg/zrlxavRZrTdpo+rJIWM" +
                "nyEqRzmvAP2kvDngY3BvH1q307xDLgyW8aGTzs9GdVBKf7x616F8SvHGvR2stl4" +
                "G0G81GU/K18sJMS/7h/iPv0r5X+JHhnXdLuIvE2r6bcWt9c3aiWaaTcZWOeue9e" +
                "DXV6butj38poqeJhGUrJu2hxc3gtrrWxaN4h0OEyEBZJLraMntggHNb4+HdnoE2J" +
                "s3lyh5kdflB9hXFfEcm78Qm1tkVXwNwU8CvQfhzeXf9n2+kayZ3QAJb3cwwo9Eyf" +
                "0qcG4tXaOrPMN9XqONOV0hxWWBPvsoHpXjvxJvpb3xHJC2QtuNoGc8nk5r6dk8Lm" +
                "KGW7u12QW8bSSEjoFGT/KvlDUna8v572QfPcStIR9TmvRs5Kx89F6mdElXLeLa4Y" +
                "UsMOGq9BEA2COoralTsKczU0PUr7SrmO80+6mtZ16PG2D/wDXHtXr/hD4wv8AJbe" +
                "JLfcOn2mEc/Vl/wAK8ZRcAcEfSpMkKD2rvpzlDY46tKFT4kfXGl6pYarZrd6bdxX" +
                "ULfxRtnHsR2P1qZmzXybpOs6npFz9o0y9mtZe5jfGfYjoa7bQ/jBr9vIsepW9vex" +
                "g4Lbdj/pxXSsQnucM8HJfDqe7uc1BIa5Lwv8AEXw/4hvY7CB5re9cZEUq9/QHvXU" +
                "SMea1UlLVHO4OLsyKY9aKjlbiihsaOeifmrMcoUZJwByazon5rE8e6y2maI6xNiW" +
                "UY+grnOpRu7HnHjTUP7S8U6hOpOwHav0FZinnoc9Kz2umllnlbPzgnNWoJAVyG96" +
                "w5rs7eWyLSuc9KkjfcCcd+QeaqsT0GPrSxMQwGMj2p3Cxclw8bJIOGBB+lUIluLe" +
                "Ty/ME0PZifmH19alldhInPyt/OgsoU9cUNJu49iPefM555r6I/Y1WCfxjqsNxHHL" +
                "G1omUcBgfm7g185O3z84r6A/Y0m2+P9RQn71kuP8AvqscQ/3bKh8R9ouuUCoB7V8" +
                "5ftbMJL/QtMR4mFtvvblDkkDovH519CT30Njp019cOFhgiaSRj2VRkn9K+MfH+u3" +
                "viDUdW12+ZvNu2PlJ2jjHCr+A/WvmcbV5Icq3Z9pwtgPb4r28vhh+b2OZ+EvhlPF" +
                "mt6lrVwisFlIAxwBX0R4b8A2V7Zhb20je2AwEZeDXkX7J18kviLVPD11IubnEkAP" +
                "U7TyPyxX10trFZ6c2AFCpXXh5L2aseVnUKkMZNS9UfNvx31G88OeCtT0/TIIjZTx" +
                "izLOx3Rb+Pl9eMjFfJLwg3OMcL7V9QftZX6QaPpenJw11PJdSD1CjC/qTXzZpdtL" +
                "eXSxQRPLLIcIiAlmPoAOpr1KUVy3Z4jepVmhfZuiUO3pnrSWsM6v5kr8/3FHArSM" +
                "e1ipGCCQRjFV5ZiLhYQNzEEknsK35UtSLt6DgeeR0pScnimvJyP546UwyHkkce9X" +
                "ckdJnBPeq8pyo55Y4p8kn7vrx7Gqc82NzA/cUmockUka3gu5KeLoLqF8NHMhT8CK" +
                "+p5X+Y18c6FcPFfLIrFSGznNfVegaodT0GyvyRuliBf8A3uh/WunCT5oHDjYWkjS" +
                "mcUVUlk9TRXTc5EjnY5BxXmHxb1VW1IWiPkqvOO1d1c3otrKa4J+4hb8a8J1i/a/" +
                "1SW4dixY9TXHWnyx9T0cPC7uSWzboWPfGKs6ZLmBDk9BWcmVUkZwetP0uTEbJnBD" +
                "VyxnqkdTjobPmYJz27UI+X4J+lVkbqc8djTYnxJnfxW3MRYv3bgxZzypDZFJvGCQ" +
                "ajchhjjnioYz8nXkDFPmFYWR+cV7l+x/chPifImf9ZZH9DXgkzYNex/sm3Pl/F6z" +
                "XtJayD9RWVV+4yo7n2D8ZNRNh8MtVZSQ00YgGP9tgp/Qmvk3X3zZO5VAvQjp1r6K" +
                "/aKvxF4LtrTdjzrpM89gCa+Z9fkhZyA7CPPUnnH0r5HMHeqkfqfCFPlwLn1cn9ys" +
                "Y/wAOdXk8P/ErTfEOzyoYL1DJsXC7CcMP++Sa++dYuA2lyMDwR2r8/o4Ue5O2Q+W" +
                "X4J549SK+0vDurLefDHSr+WXO+yiaRz6hRuP5g11YGd20eXxdhlCFOqvNfqv1Pk3" +
                "9qrWxe/EOazRspYW8cA9mI3N/MVl/s4eJNC8O+M0k1rTra5a5AhtbmcArZyk8SnP" +
                "GAe/auI+IWtNrnijUdVYsftd1JMM9lLHaPwGBWZZnaoOeDXv1KSq03SezR8JGTg+" +
                "ZHf8AxK8dv4wnjuDpdhYQxl2Bit0R5MkkF2AznnpXntq5fzLlj/rD8oP93tS6lMT" +
                "EsCn/AFhwcdh3qKWT5ABwAOhp0aUKMVCGyCcnN8z6ivMSxPFN8w4BLDP5VXLtu6k" +
                "e9MeYLwGIBq3MlRLUsv7vO/cf5VnTyFrd2JJy2M/SpppmFuSZRnHSqEzlbZFIxuy" +
                "1YVahpCI+xbY+fevevgvrH2rQprB2y0DbkB/un/69fP0TY716P8FL8w+IhCWIWaN" +
                "lx79f6Vvgav2TnxlO8bnuUsnrRVGWb3or0bnmWPO/G12YfDNzhsF8LXj/AEHWu/8" +
                "AiXeY0uC3B5d9xH0rgBgjBNedineVj1cMrRuTxSkJg9PUUlk4WV+evNVldoWwwyp" +
                "pYpMXBYc5rkVTVHQ46Gx5uFPI44ohf5gc1UDfLipEcbcCunmMrF/zMt6U3eQ7jPf" +
                "NVlkBIpZWAdTnqKpSE0Fy3ynk9a9P/ZiuhF8Y9C5wHEi/+O5/pXlU7HHSuz+BV+L" +
                "L4peHpycBbhl/NGqJy0Y0j6k/aI1XzrjTrJGBAdiQfpj+teD6ncTTXJtVw3z46DJ" +
                "PTr6V33xrvGudTtZWJywYrXmenSQuGLoS4brjjFfLY3+Oz9Y4ZjbLKfm3+ZqWSMo" +
                "MLqNytjPfPTrXtF9rzaX+y5PMX2yrDJaLg9GZ2Tj8DXicM9uYyqgiQH8MVf8AiT4" +
                "h+y/AbRdFDYe61CeR1/2UY/1Na5XrWdzj4xX+wx/xfozxG5mEt0SOg6Veg4TIrHt" +
                "mLSZPc1duZ/KtyR1IwPrX0kZbyPzSS6DPMMl00g5C/Kv9aSZlA7Fj1z1qGFxHGBk" +
                "57n3qKR8DlRj9anmsh2HSTFR1PHSq6SMzE9aZM5I602KQICT17VzSqXkaqOhNdOv" +
                "khV61HdAjaCeijAqIsWcZp1wWaQs3Ws5T5rspKwwHmun+H96LHxLYzM2FEoDH0B4" +
                "P865erFncCKVWYcd6rDVVCabIqw5otH0zLLyeaKwdI1Jb/SbW7SQOJI1JI9cc/rR" +
                "Xv7niWseXfEWbN1AhOcpxXLKcoK0vGVwZtZYZyEAUVlRN8uK8evUvVaPXoxtTQ7zF5VxkVGxVXBU8U5sdDURGDXLOTN0i4j5TrT0k468VUhbjFSBhmuiNS6IcS2shznNOkk+UHPQ1VB5pxbKkZrTnI5SSR8r1rZ+H9z9n8ZaNJnG29jGc+px/WufLEiptMufsuo21yDjyZkkz/usD/SplIpI+ifjVf4utNELbfLhYhvfIrgLCYpGbgyKZGbJ55z16V0PxXu0a50wk7l+zknB65NcPY3OGDnO3PrXz+MV6rP0/IKijgaUfJ/mzoVunfzJTJ85b15rivHeuXOo/ZrGVmKWYdRnuWbcTW8J1Ls4U7M9+1cBqtwLjUJpVGFZyQPbPFbZerSkzg4trReHpw7u/okv+CFqcHNFzL5kgXsvP41CrhVzTAxxn15r13OySPgOXW5Oz4XoBVaWRm6saVmJ61GTWNSbZcVYSiiiudlCqcMDTpA2AWGPTNMBwc0EknJOapPSwBTk25w1NopRdmB6F8MNRZEudNZ8qv7xPb1oqh8O483Vxe8ABAmPeivosM70keLibKo7HLatOLjUJ5QcgucfSqw6UUV4M23JtnsRVkkODBhhqawUdDmiipk7odgU4NODUUU4t2AeGpd1FFaqTFZDd3GKTdRRScmFj0nxJqH2zTdFZpck2EYZie+OaxrWYsgQv8ufwoory8SvfbPt8om1Qprsv1Yl/dmCynCtxjA+vSuOZsvRRXRhtIP1PIz+pKdaKfYCc8U7PFFFdKZ4AxjSUUVnJjCiiipAKDiiimtgCiiigDqPAk7RXc0OflkTP5UUUV9Dhf4SPIxS/eM//2Q==";
        }

        public Task<object> GetUserProfileAsync()
        {
            throw new NotImplementedException();
        }

        //public async Task<UserProfile> GetUserProfileAsync()
        //{
        //    await Task.Delay(1000);
        //    return new UserProfile("N04944949", "chrisharrison1@nova.edu")
        //    {
        //        Name = "Chris Harrison"
        //    };
        //}
    }
}
