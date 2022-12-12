using c_sherp_project_api.Models;

namespace c_sherp_project_api.lib;

public class Lib {
    public static Result GetRoundResult(Choice player, Choice bot){
            Result result = (Result)((player - bot + 3) % 3);
            return result;
    }

}