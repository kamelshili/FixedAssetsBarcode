package crc64053cca3b2898d050;


public class SingleItemCustomViewProviderContainer
	extends crc64053cca3b2898d050.CustomViewProviderContainer
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("DevExpress.Maui.Scheduler.Android.Internal.SingleItemCustomViewProviderContainer, DevExpress.Maui.Scheduler", SingleItemCustomViewProviderContainer.class, __md_methods);
	}


	public SingleItemCustomViewProviderContainer ()
	{
		super ();
		if (getClass () == SingleItemCustomViewProviderContainer.class) {
			mono.android.TypeManager.Activate ("DevExpress.Maui.Scheduler.Android.Internal.SingleItemCustomViewProviderContainer, DevExpress.Maui.Scheduler", "", this, new java.lang.Object[] {  });
		}
	}

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
