package mono.com.devexpress.scheduler.views.interop;


public class NativeGestureListenerImplementor
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		com.devexpress.scheduler.views.interop.NativeGestureListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_doubleTap:(Lcom/devexpress/scheduler/views/hittesting/SchedulerHitInfo;)V:GetDoubleTap_Lcom_devexpress_scheduler_views_hittesting_SchedulerHitInfo_Handler:DevExpress.Android.Scheduler.Views.Interop.INativeGestureListenerInvoker, DevExpress.Android.Scheduler\n" +
			"n_longPress:(Lcom/devexpress/scheduler/views/hittesting/SchedulerHitInfo;)V:GetLongPress_Lcom_devexpress_scheduler_views_hittesting_SchedulerHitInfo_Handler:DevExpress.Android.Scheduler.Views.Interop.INativeGestureListenerInvoker, DevExpress.Android.Scheduler\n" +
			"n_tap:(Lcom/devexpress/scheduler/views/hittesting/SchedulerHitInfo;)V:GetTap_Lcom_devexpress_scheduler_views_hittesting_SchedulerHitInfo_Handler:DevExpress.Android.Scheduler.Views.Interop.INativeGestureListenerInvoker, DevExpress.Android.Scheduler\n" +
			"";
		mono.android.Runtime.register ("DevExpress.Android.Scheduler.Views.Interop.INativeGestureListenerImplementor, DevExpress.Android.Scheduler", NativeGestureListenerImplementor.class, __md_methods);
	}


	public NativeGestureListenerImplementor ()
	{
		super ();
		if (getClass () == NativeGestureListenerImplementor.class) {
			mono.android.TypeManager.Activate ("DevExpress.Android.Scheduler.Views.Interop.INativeGestureListenerImplementor, DevExpress.Android.Scheduler", "", this, new java.lang.Object[] {  });
		}
	}


	public void doubleTap (com.devexpress.scheduler.views.hittesting.SchedulerHitInfo p0)
	{
		n_doubleTap (p0);
	}

	private native void n_doubleTap (com.devexpress.scheduler.views.hittesting.SchedulerHitInfo p0);


	public void longPress (com.devexpress.scheduler.views.hittesting.SchedulerHitInfo p0)
	{
		n_longPress (p0);
	}

	private native void n_longPress (com.devexpress.scheduler.views.hittesting.SchedulerHitInfo p0);


	public void tap (com.devexpress.scheduler.views.hittesting.SchedulerHitInfo p0)
	{
		n_tap (p0);
	}

	private native void n_tap (com.devexpress.scheduler.views.hittesting.SchedulerHitInfo p0);

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
