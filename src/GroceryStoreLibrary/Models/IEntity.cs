namespace GroceryStoreLibrary.Models
{
    /// <summary>
    /// Every database entity (record) shares this common interface.
    /// </summary>
    public interface IEntity
    {
        /// <summary>Record identifier</summary>
        int Id { get; set; }
    }
}
