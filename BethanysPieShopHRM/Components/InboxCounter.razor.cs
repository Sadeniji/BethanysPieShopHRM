using BethanysPieShopHRM.State;
using Microsoft.AspNetCore.Components;

namespace BethanysPieShopHRM.Components;

public partial class InboxCounter
{
    [Inject] 
    public ApplicationState ApplicationState { get; set; }
    private int MessageCount;

    protected override void OnInitialized()
    {
        MessageCount = new Random().Next(10);
        ApplicationState.NumberOfMessages = MessageCount;
    }
}