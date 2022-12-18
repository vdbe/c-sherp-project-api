using c_sherp_project_api.Models;

namespace c_sherp_project_api.lib;

public class Lib {
    public static Result GetRoundResult(Choice player, Choice bot){
            Result result = (Result)((player - bot + 3) % 3);
            return result;
    }

    public static void UpdateGame(ref Game game, Result result) {
        if (game.Active == false) {
            return;
        }

        switch (result)
        {
            case Result.Draw:
                {
                    break;
                }
            case Result.Win:
                {
                    game.Score++;
                    break;
                }
            case Result.Loss:
                {
                    game.Active = false;
                    break;
                }
            default:
                {
                    // Unreachable
                    break;
                }
        }

    }
}