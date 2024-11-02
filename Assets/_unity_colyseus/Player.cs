// 
// THIS FILE HAS BEEN GENERATED AUTOMATICALLY
// DO NOT CHANGE IT MANUALLY UNLESS YOU KNOW WHAT YOU'RE DOING
// 
// GENERATED USING @colyseus/schema 2.0.34
// 

using Colyseus.Schema;
using Action = System.Action;

public partial class Player : Schema {
	[Type(0, "boolean")]
	public bool connected = default(bool);

	[Type(1, "string")]
	public string userId = default(string);

	[Type(2, "string")]
	public string username = default(string);

	[Type(3, "number")]
	public float score = default(float);

	/*
	 * Support for individual property change callbacks below...
	 */

	protected event PropertyChangeHandler<bool> __connectedChange;
	public Action OnConnectedChange(PropertyChangeHandler<bool> __handler, bool __immediate = true) {
		if (__callbacks == null) { __callbacks = new SchemaCallbacks(); }
		__callbacks.AddPropertyCallback(nameof(this.connected));
		__connectedChange += __handler;
		if (__immediate && this.connected != default(bool)) { __handler(this.connected, default(bool)); }
		return () => {
			__callbacks.RemovePropertyCallback(nameof(connected));
			__connectedChange -= __handler;
		};
	}

	protected event PropertyChangeHandler<string> __userIdChange;
	public Action OnUserIdChange(PropertyChangeHandler<string> __handler, bool __immediate = true) {
		if (__callbacks == null) { __callbacks = new SchemaCallbacks(); }
		__callbacks.AddPropertyCallback(nameof(this.userId));
		__userIdChange += __handler;
		if (__immediate && this.userId != default(string)) { __handler(this.userId, default(string)); }
		return () => {
			__callbacks.RemovePropertyCallback(nameof(userId));
			__userIdChange -= __handler;
		};
	}

	protected event PropertyChangeHandler<string> __usernameChange;
	public Action OnUsernameChange(PropertyChangeHandler<string> __handler, bool __immediate = true) {
		if (__callbacks == null) { __callbacks = new SchemaCallbacks(); }
		__callbacks.AddPropertyCallback(nameof(this.username));
		__usernameChange += __handler;
		if (__immediate && this.username != default(string)) { __handler(this.username, default(string)); }
		return () => {
			__callbacks.RemovePropertyCallback(nameof(username));
			__usernameChange -= __handler;
		};
	}

	protected event PropertyChangeHandler<float> __scoreChange;
	public Action OnScoreChange(PropertyChangeHandler<float> __handler, bool __immediate = true) {
		if (__callbacks == null) { __callbacks = new SchemaCallbacks(); }
		__callbacks.AddPropertyCallback(nameof(this.score));
		__scoreChange += __handler;
		if (__immediate && this.score != default(float)) { __handler(this.score, default(float)); }
		return () => {
			__callbacks.RemovePropertyCallback(nameof(score));
			__scoreChange -= __handler;
		};
	}

	protected override void TriggerFieldChange(DataChange change) {
		switch (change.Field) {
			case nameof(connected): __connectedChange?.Invoke((bool) change.Value, (bool) change.PreviousValue); break;
			case nameof(userId): __userIdChange?.Invoke((string) change.Value, (string) change.PreviousValue); break;
			case nameof(username): __usernameChange?.Invoke((string) change.Value, (string) change.PreviousValue); break;
			case nameof(score): __scoreChange?.Invoke((float) change.Value, (float) change.PreviousValue); break;
			default: break;
		}
	}
}

