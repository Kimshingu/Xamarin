package md54de44c04a713f88a86b69c974c0a0a44;


public class CallHistoryActivity
	extends android.app.ListActivity
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onCreate:(Landroid/os/Bundle;)V:GetOnCreate_Landroid_os_Bundle_Handler\n" +
			"";
		mono.android.Runtime.register ("Andoroid_Hello.CallHistoryActivity, Andoroid_Hello", CallHistoryActivity.class, __md_methods);
	}


	public CallHistoryActivity ()
	{
		super ();
		if (getClass () == CallHistoryActivity.class)
			mono.android.TypeManager.Activate ("Andoroid_Hello.CallHistoryActivity, Andoroid_Hello", "", this, new java.lang.Object[] {  });
	}


	public void onCreate (android.os.Bundle p0)
	{
		n_onCreate (p0);
	}

	private native void n_onCreate (android.os.Bundle p0);

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
