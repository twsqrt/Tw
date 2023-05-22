using System;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMoveBuilder : MonoBehaviour 
{
    [SerializeField] private PlayerMoveButton[] _moveButtons;
    [SerializeField] private MoveBuildingSelector _buildingSelector;
    [SerializeField] private MoveCoordinateSelector _coordinateSelector;
    [SerializeField] private MoveResourcesSelector _resourceSelector;
    [SerializeField] private MoveTimeSelector _timeSelector;

    public event Action<PlayerMove> OnMoveBuilt;

    private bool _buildingProcessEnable;
    private CancellationTokenSource _buildingCancellation;


    //template solution
    public PlayerState Player;

    public void Init()
    {
        foreach(PlayerMoveButton button in _moveButtons)
        {
            button.OnButtonClick += TryBuild;
        }

        _buildingSelector.Init();
        _coordinateSelector.Init();
        _resourceSelector.Init();
        _timeSelector.Init();

        _buildingProcessEnable = false;
    } 

    public void BuildingCancelHandler()
    {
        _buildingCancellation.Cancel();
    }

    public async void TryBuild(PlayerMoveType moveType)
    {
        if(_buildingProcessEnable)
            return;

        _buildingProcessEnable = true;
        PlayerMove move = PlayerMoveFactory.Create(moveType, Player);

        _buildingCancellation?.Cancel();
        _buildingCancellation?.Dispose();
        _buildingCancellation = new CancellationTokenSource();

        try
        {
            if(await BuildingProcess(move, _buildingCancellation.Token))
            {
                OnMoveBuilt?.Invoke(move);
            }
        }
        catch(TaskCanceledException) {}
        finally
        {
            _buildingProcessEnable = false;
        }
    }

    private async Task<bool> BuildingProcess(PlayerMove move, CancellationToken token)
    {
        if(move.IsParameterizedBy(MoveParameters.Building))
        {
            await _buildingSelector.StartSelectingAsync(move as IBuildingMove, token);
        }

        if(move.IsParameterizedBy(MoveParameters.Coordinate))
        {
            await _coordinateSelector.StartSelectingAsync(move as ICoordinateMove, token);
        }

        if(move.IsParameterizedBy(MoveParameters.Resources))
        {
            await _resourceSelector.StartSelectingAsync(move as IResoucesMove, token);
        }

        if(move.IsParameterizedBy(MoveParameters.Time))
        {
            await _timeSelector.StartSelectingAsync(move as ITimeMove, token);
        }

        return token.IsCancellationRequested == false;
    }
}
